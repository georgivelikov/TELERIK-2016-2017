function solve() {
    $.fn.datepicker = function () {
        var $input = $('#date').addClass('datepicker');
        var $firstDiv = $input.parent();
        var $wrapper = $('<div>').addClass('datepicker-wrapper').append($input);
        $firstDiv.append($wrapper);

        $template = $('<div>').addClass('picker');
        $wrapper.append($template);

        $controler = $('<div>').addClass('controls');
        $template.append($controler);

        $buttonLeft = $('<button>').addClass('btn left').html('<');
        $controler.append($buttonLeft);

        $currentMonthSpan = $('<div>').addClass('current-month');
        $controler.append($currentMonthSpan);

        $buttonRight = $('<button>').addClass('btn right').html('>');
        $controler.append($buttonRight);

        var $table = $('<table>').addClass('calendar');

        var daysNames = ['Su','Mo','Tu','We','Th','Fr','Sa'];
        var monthsNames = ['January','February','March','April','May','June','July','August','September','October','November','December'];
        var monthsDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

        var $thead = $('<thead>');
        $table.append($thead);
        var $tr1 = $('<tr>');
        $thead.append($tr1);
        for (var j = 0; j < 7; j++) {
            var $th = $('<th>').html(daysNames[j]);
            $tr1.append($th);
        }
        
        var $tbody = initialTableBody(monthsDays);
        $table.append($tbody);
        
        $template.append($table);

        var $currentDateDiv = $('<div>').addClass('current-date');
        $template.append($currentDateDiv);

        $('.datepicker').click(function(){
            $template.toggleClass('picker-visible');
        });

        var currentDate = new Date();
        var currentYear = currentDate.getFullYear();
        var currentMonthCount = currentDate.getMonth();

        var permDay = currentDate.getDay();
        var permMonth = currentMonthCount;
        var permYear = currentYear;

        var $currentDateSpan = $('<div>').addClass('current-date-link').html(currentDate.getDay() + ' ' + monthsNames[currentMonthCount] + ' ' + currentYear);
        $currentDateDiv.append($currentDateSpan);
        
        $currentMonthSpan.html(monthsNames[currentMonthCount] + ' ' + currentYear);

        $('.left').on('click', function() {
            currentMonthCount--;
            if(currentMonthCount < 0) {
                currentMonthCount = 11;
                currentYear--;
            }
            currentMonth = currentMonthCount;
            $currentMonthSpan.html(monthsNames[currentMonth] + ' ' + currentYear);
            updateTableBody($tbody, monthsDays, currentMonth, currentYear);
        });
        $('.right').on('click', function() {
            currentMonthCount++;
            if(currentMonthCount > 11) {
                currentMonthCount = 0;
                currentYear++;
            }
            currentMonth = currentMonthCount;
            $currentMonthSpan.html(monthsNames[currentMonth] + ' ' + currentYear);
            updateTableBody($tbody, monthsDays, currentMonth, currentYear);
        });
        $('td.current-month').on('click', function () {
            $this = $(this);
            var currentDay = $this.html();

            $input.val(currentDay + '/' + (currentMonthCount + 1) + '/' + currentYear);
            $template.toggleClass('picker-visible');
        });
        
        $('.current-date-link').on('click', function () {
            $this = $(this);
            var currentDay = $this.html().split(' ')[0];
            $input.val(permDay + '/' + (permMonth + 1) + '/' + permYear);
            $template.toggleClass('picker-visible');
        });
        
        function initialTableBody(monthsDays){
            var $tableBody = $('<tbody>');
            var currentDate = new Date();
            var currentWeekDay = currentDate.getDay();
            //first row
            var $firstRow = $('<tr>');
            var firstDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);
            var firstDateWeekDay = firstDate.getDay();

            var minIndex = currentDate.getMonth() - 1;
            if(minIndex < 0){
                minIndex = 0;
            }
            var prevMonthsDays = monthsDays[minIndex];
            var tdClass = 'another-month';
            for (var i = firstDateWeekDay - 1; i >= 0; i--) {
                var $td = $('<td>');
                $td.html(prevMonthsDays - i).addClass(tdClass);
                $firstRow.append($td);
            }
            var counter = 1;
            tdClass = 'current-month';
            for (var i = firstDateWeekDay; i < 7; i++) {
                var $td = $('<td>').addClass(tdClass);
                $td.html(counter);
                $firstRow.append($td);
                counter++;
            }
            $tableBody.append($firstRow);

            var tdClass = 'current-month';
            for (var i = 0; i < 5; i++) {
                var $tr = $('<tr>');
                for (var j = 0; j < 7; j++) {
                    var $td = $('<td>').addClass(tdClass);
                    $td.html(counter);
                    $tr.append($td);
                    counter++;
                    if(counter > monthsDays[currentDate.getMonth()]){
                        counter = 1;
                        tdClass = 'another-month';
                    }
                }
                $tableBody.append($tr);
            }
            
            return $tableBody;
        }

        function updateTableBody($tb, monthsDays, currentMonth, currentYear){
            $tb.html('');
            var $firstRow = $('<tr>');
            var firstDate = new Date(currentYear, currentMonth, 1);
            var firstDateWeekDay = firstDate.getDay();

            var minIndex = currentMonth - 1;
            if(minIndex < 0){
                minIndex = 0;
            }
            var prevMonthsDays = monthsDays[minIndex];
            var tdClass = 'another-month';
            for (var i = firstDateWeekDay - 1; i >= 0; i--) {
                var $td = $('<td>');
                $td.html(prevMonthsDays - i).addClass(tdClass);
                $firstRow.append($td);
            }
            var counter = 1;
            tdClass = 'current-month';
            for (var i = firstDateWeekDay; i < 7; i++) {
                var $td = $('<td>').addClass(tdClass);
                $td.html(counter);
                $firstRow.append($td);
                counter++;
            }
            $tb.append($firstRow);
            var tdClass = 'current-month';
            for (var i = 0; i < 5; i++) {
                var $tr = $('<tr>');
                for (var j = 0; j < 7; j++) {
                    var $td = $('<td>').addClass(tdClass);
                    $td.html(counter);
                    $tr.append($td);
                    counter++;
                    if(counter > monthsDays[currentMonth]){
                        counter = 1;
                        tdClass = 'another-month';
                    }
                }
                $tb.append($tr);
            }

            $('td.current-month').on('click', function () {
                $this = $(this);
                var currentDay = $this.html();

                $input.val(currentDay + '/' + (currentMonthCount + 1) + '/' + currentYear);
                $template.toggleClass('picker-visible');
            });
        }

        $(document).click(function (ev) {
            if (!$(ev.target).parents('.datepicker-wrapper').length) {
                if ($template.hasClass('picker-visible')) {
                    $template.toggleClass('picker-visible');
                }
            }
        });

        return $(this);
    };
};

if(typeof module !== 'undefined') {
    module.exports = solve;
}