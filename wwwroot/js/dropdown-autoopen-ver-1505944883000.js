
;(function($, window, undefined) {

 
 var $allDropdowns = $();

 
 $.fn.dropdownHover = function(options) {

 
 $allDropdowns = $allDropdowns.add(this.parent());
return this.each(function() {
var $this = $(this).parent(),
defaults = {
delay: 500,
instantlyCloseOthers: true
},
data = {
delay: $(this).data('delay'),
instantlyCloseOthers: $(this).data('close-others')
},
options = $.extend(true, {}, defaults, options, data),
timeout;
$this.hover(function() {
if(options.instantlyCloseOthers === true)
$allDropdowns.removeClass('open');
window.clearTimeout(timeout);
$(this).addClass('open');
}, function() {
timeout = window.setTimeout(function() {
$this.removeClass('open');
}, options.delay);
});
});
};
})(jQuery, this);