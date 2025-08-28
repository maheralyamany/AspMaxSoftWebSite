$(function () {
	function equalheight(e) {
		
		var cntnt = $("#main-container");
		
		var ftr = $("footer");
		if (!cntnt || !ftr)
			return;
		//var navb = $("nav.navbar");
		
		var ftrH = ftr.outerHeight();
		var contentH = cntnt.outerHeight();
		
		var cp = cntnt.position();
		var windowH = $(window).height();
		var vTop = contentH +20;
		if (cp)
			vTop += cp.top;
		
		var fptop = ftr.position().top;
		var hh = ftrH + vTop;
		if (hh <= windowH) {
			$(ftr).css('position', 'absolute');
			$(ftr).css('bottom', '0px');
		} else {
			$(ftr).css('position', 'relative');
		}

		/*if (fptop <= vTop) {
			fptop = vTop + 10;
			$(ftr).css('position', 'absolute');
			ftr.offset({
				top: fptop
			});
		} else {
			$(ftr).css('position', 'absolute');
		}*/
		/*
		windowH = windowH - (ftr.height() + navb.height()) - 5;*/
		
		
		
		
		
		

	}
	$(window, "#main-container,#mainContent").resize(function () {
		equalheight($(this));
	}).trigger("resize");
	/*$(window).resize(function () {
		equalheight();
	});
	$("#main-container").on("resize", function () {
		equalheight();
	}).trigger("resize");*/
	
});