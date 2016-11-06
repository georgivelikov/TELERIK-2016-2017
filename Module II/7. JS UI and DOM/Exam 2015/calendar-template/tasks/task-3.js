function solve() {
    return function (selector) {
        var template = '<div class="events-calendar">'+
'<h2 class="header">'+
'Appointments for <span class="month">{{month}}</span> <span class="year">{{year}}</span>'+
'</h2>'+
'{{#days}}'+
'<div class="col-date">'+
'<div class="date">{{this.day}}</div>'+
'<div class="events">'+
'{{#this.events}}'+
'{{#if this.title}}'+
'<div class="event {{this.importance}}" title="{{this.comment}}">'+
'<div class="title">{{this.title}}</div>'+
'<span class="time">at: {{this.time}}</span>'+
'</div>'+
'{{else}}'+
'<div class="event none">'+
'<div class="title">Free slot</div>'+
'</div>'+
'{{/if}}'+            
'{{/this.events}}'+
'</div>'+
'</div>'+   
'{{/days}}'+
'</div>';
        //var el = document.getElementById('calendar-template');
        //template = el.innerHTML;
        //console.log(template);
        document.getElementById(selector).innerHTML = template;
    };
}
module.exports = solve;