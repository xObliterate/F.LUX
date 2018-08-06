//room dropdown
document.addEventListener('DOMContentLoaded', function () {
    var dd = document.querySelectorAll('.dropdown-trigger');
    var instances = M.Dropdown.init(dd, {
        inDuration: 300,
        outDuration: 225,
        hover: true,
        coverTrigger: false,
        alignment: 'right',
    });
});
//profile dropdown
document.addEventListener('DOMContentLoaded', function () {
    var dd = document.querySelectorAll('.dropdown-trigger2');
    var instances = M.Dropdown.init(dd, {
        coverTrigger: false,
        alignment: 'left',
        constrainWidth: false
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var sideNav = document.querySelectorAll('.sidenav');
    var instance = M.Sidenav.init(sideNav, {});
});

document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.collapsible');
    var instances = M.Collapsible.init(elems, {});
});

document.addEventListener('DOMContentLoaded', function () {
    var slider = document.querySelectorAll('.slider');
    var instances = M.Slider.init(slider, {
        indicators: false,
        height: 500,
        transition: 500,
        interval: 6000
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var mb = document.querySelectorAll('.materialboxed');
    var instances = M.Materialbox.init(mb, {});
});

var prevScrollpos = window.pageYOffset;
window.onscroll = function () {
    var currentScrollPos = window.pageYOffset;
    if (prevScrollpos > currentScrollPos) {
        document.getElementById("navbar").style.top = "0";
    } else {
        document.getElementById("navbar").style.top = "-60px";
    }
    prevScrollpos = currentScrollPos;
}