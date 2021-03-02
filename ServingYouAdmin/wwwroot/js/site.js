const inputs = document.querySelectorAll(".form-input");

function focusFunc() {
    let parent = this.parentNode.parentNode;
    parent.classList.add("focus");
}

function blurFunc() {
    let parent = this.parentNode.parentNode;
    if (this.value == "") {
        parent.classList.remove("focus");
    }
}

inputs.forEach((input) => {
    input.addEventListener("focus", focusFunc);
    input.addEventListener("blur", blurFunc);
});


function validateFile(file) {
    const extensions = ['gif', 'jpg', 'png'];
    const maxSize = 5000000;

    console.log(file.files.length);
    if (file.files.length > 0) { 
        const { name: fileName, size: fileSize } = file.files[0];
        const fieExtension = fileName.split(".").pop();

        if (!extensions.includes(fieExtension)) {
            alert(`${fieExtension} file not allowed to upload.`)
            file.value = null;
        } else if (fileSize > maxSize) {
            alert("Please upload a file less than 5M.")
            file.value = null;
        }
    }
}   

function showProperty(id) {
    const control = document.getElementById(id);

    if (control.style.display === "block") {
        control.style.display = "none";
    }
    else {
        control.style.display = "block";
        document.getElementById("SpecialPrice").value = 0;
    }
}

const validateSpecialPrice = () => {
    const value = document.getElementById("SpecialPrice").value;
    const control = document.getElementById("specialPrice-error");    

    if (value <= 0) {
        control.innerHTML = "The Special Price must be more than 0.";
    }
    else {
        control.innerHTML = "";
    }
}

function getItems() {       
    const apiUrl = "";    

    return fetch(apiUrl)
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => {
            console.error('Unable to get items.', error);
        });        
}

async function createMenuToAWS() {
    const apiUrl = "";

    const menu = {
        "id": 5,
        "name": "pizza",
        "category": "Australian",
        "description": "delicious",
        "price": 20.95,
        "special": false,
        "image": "pizza.jpg"
    }

    
    return await fetch(apiUrl, {
        method: 'POST',
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(menu)
    }).then(response => response.json())
        .then(data => data)
        .catch(error => console.log("Unable to add an item", error));      
}
