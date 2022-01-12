window.onscroll = function() { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 80) {
        document.getElementById("NavBar").style.transition = "0.5s"
        document.getElementById("NavBar").style.background = " rgb(10, 10, 10,0.80)";

    } else {
        document.getElementById("NavBar").style.transition = "0.5s"
        document.getElementById("NavBar").style.background = "transparent";

    }
}