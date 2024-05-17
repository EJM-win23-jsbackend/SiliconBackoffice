function fadeInElement(wrapper) {
    const element = document.getElementById(wrapper);
    if (element) {
        element.style.transition = "opacity 1s ease-in-out";
        element.style.opacity = 1;
    }
}