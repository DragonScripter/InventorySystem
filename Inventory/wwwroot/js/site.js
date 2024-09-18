// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showForm()
{
    document.getElementById("form-container").style.display = "flex";
}

function closeForm()
{
    document.getElementById("form-container").style.display = 'none';
}

window.onclick = function (event) {
    const outside = document.getElementById("form-container");
    if (event.target == outside) {
        closeForm();
    }
}