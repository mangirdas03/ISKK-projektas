
function startTime() {
    const today = new Date();
    let h = today.getHours();
    let m = today.getMinutes();
    let s = today.getSeconds();

    // Pridedami nuliai, kad gražiau atrodytų laiko formatas
    var ampm = h >= 12 ? 'PM' : 'AM';
    h = checkTime(h);
    m = checkTime(m);
    s = checkTime(s);

    document.getElementById('time').innerHTML = h + ":" + m + ":" + s + " " + ampm;
    document.getElementById('date').innerHTML = today.getDate() + "." + (today.getMonth() + 1) + "." + today.getFullYear();
    setTimeout(startTime, 1000); // kas kiek laiko atnaujinamas laikas
}

function checkTime(i) {
    if (i < 10)
        i = "0" + i; // add zero in front of numbers < 10

    return i;
}


function validateSearchForm() {
    let x = document.forms["myForm1"]["category_select"].value;
    if (x == "0") {
        alert("Please select category!");
        return false;
    }
}

function validateAddForm() {

    const fields = ["model", "material", "size", "price", "color", "batch", "pdate", "id"];
    for (let i = 0; i < fields.length; i++) {
        let field = document.forms["myForm2"][fields[i]].value;
        if (field === "" || field === "0") {
            alert("Please fill " + fields[i] + " field!");
            return false;
        }
    }
    alert("Shoe added!");
}


var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click",
        function () {
            this.classList.toggle("active");
            var panel = this.nextElementSibling;
            if (panel.style.display === "block") {
                panel.style.display = "none";
            }
            else {
                panel.style.display = "block";
            }
        }
    );
}
