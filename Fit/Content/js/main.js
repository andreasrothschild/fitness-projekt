/**
 * main.js
 * http://www.codrops.com
 *
 * Licensed under the MIT license.
 * http://www.opensource.org/licenses/mit-license.php
 * 
 * Copyright 2014, Codrops
 * http://www.codrops.com
 */
(function() {

	var bodyEl = document.body,
		content = document.querySelector( 'main' ),
		openbtn = document.getElementById( 'open-button' ),
		closebtn = document.getElementById( 'close-button' ),
		isOpen = false;

	function init() {
		initEvents();
	}

	function initEvents() {
		openbtn.addEventListener( 'click', toggleMenu );
		if( closebtn ) {
			closebtn.addEventListener( 'click', toggleMenu );
		}

		// close the menu element if the target it´s not the menu element or one of its descendants..
		content.addEventListener( 'click', function(ev) {
			var target = ev.target;
			if( isOpen && target !== openbtn ) {
				toggleMenu();
			}
		} );
	}

	function toggleMenu() {
		if( isOpen ) {
			classie.remove( bodyEl, 'show-menu' );
		}
		else {
			classie.add( bodyEl, 'show-menu' );
		}
		isOpen = !isOpen;
	}

	init();

	window.sr = new scrollReveal();

})();

window.onload = function() {
  var heart = document.getElementsByClassName("heart");
  var classname = document.getElementsByClassName("tabitem");
  var boxitem = document.getElementsByClassName("box");

  var clickFunction = function(e) {
    e.preventDefault();
    var a = this.getElementsByTagName("a")[0];
    var span = this.getElementsByTagName("span")[0];
    var href = a.getAttribute("href").replace("#", "");
    for (var i = 0; i < boxitem.length; i++) {
      boxitem[i].className = boxitem[i].className.replace(/(?:^|\s)show(?!\S)/g, '');
    }
    document.getElementById(href).className += " show";
    for (var i = 0; i < classname.length; i++) {
      classname[i].className = classname[i].className.replace(/(?:^|\s)active(?!\S)/g, '');
    }
    this.className += " active";
    span.className += 'active';
    var left = a.getBoundingClientRect().left;
    var top = a.getBoundingClientRect().top;
    var consx = (e.clientX - left);
    var consy = (e.clientY - top);
    span.style.top = consy + "px";
    span.style.left = consx + "px";
    span.className = 'clicked';
    span.addEventListener('webkitAnimationEnd', function(event) {
      this.className = '';
    }, false);
  };

  for (var i = 0; i < classname.length; i++) {
    classname[i].addEventListener('click', clickFunction, false);
  }
  for (var i = 0; i < heart.length; i++) {
    heart[i].addEventListener('click', function(e) {
      var classString = this.className,
        nameIndex = classString.indexOf("active");
      if (nameIndex == -1) {
        classString += ' ' + "active";
      } else {
        classString = classString.substr(0, nameIndex) + classString.substr(nameIndex + "active".length);
      }
      this.className = classString;

    }, false);
  }
}