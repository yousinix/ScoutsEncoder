$(function() {
  // Fit Text Plugin for Main Header
  $("h1").fitText(1.2, {
    minFontSize: "35px",
    maxFontSize: "72px"
  });

  // Closes the Responsive Menu on Menu Item Click
  $(".navbar-collapse > ul > a").click(function() {
    $('.navbar-collapse').collapse('hide');
  });

  // jQuery for page scrolling feature - requires jQuery Easing plugin
  $("a.page-scroll").bind("click", function(event) {
    var $anchor = $(this);
    $("html, body")
      .stop()
      .animate(
        {
          scrollTop: $($anchor.attr("href")).offset().top - 50
        },
        1250,
        "easeInOutExpo"
      );
    event.preventDefault();
  });

  // Highlight the top nav as scrolling occurs
  $("body").scrollspy({
    target: "#mainNav",
    offset: 50
  });

  // Offset for Main Navigation
  $(window).scroll(function() {
    var scrollValue = $(window).scrollTop();
    if (scrollValue > 100) {
      $("#mainNav").addClass("affix");
    } else {
      $("#mainNav").removeClass("affix");
    }
  });
});
