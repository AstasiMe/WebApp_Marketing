// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function calendar(id, year, month) {
    var Dlast = new Date(year, month + 1, 0).getDate(),
        D = new Date(year, month, Dlast),
        DNlast = new Date(D.getFullYear(), D.getMonth(), Dlast).getDay(),
        DNfirst = new Date(D.getFullYear(), D.getMonth(), 1).getDay(),
        calendar = '<tr>',
        month = ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"];
    if (DNfirst != 0) {
        for (var i = 1; i < DNfirst; i++) calendar += '<td>';
    } else {
        for (var i = 0; i < 6; i++) calendar += '<td>';
    }
    for (var i = 1; i <= Dlast; i++) {
        if (i == new Date().getDate() && D.getFullYear() == new Date().getFullYear() && D.getMonth() == new Date().getMonth()) {
            calendar += '<td class="today">' + i;
        } else {
            calendar += '<td>' + i;
        }
        if (new Date(D.getFullYear(), D.getMonth(), i).getDay() == 0) {
            calendar += '<tr>';
        }
    }
    for (var i = DNlast; i < 7; i++) calendar += '<td> ';
    document.querySelector('#' + id + ' tbody').innerHTML = calendar;
    document.querySelector('#' + id + ' thead td:nth-child(2)').innerHTML = month[D.getMonth()] + ' ' + D.getFullYear();
    document.querySelector('#' + id + ' thead td:nth-child(2)').dataset.month = D.getMonth();
    document.querySelector('#' + id + ' thead td:nth-child(2)').dataset.year = D.getFullYear();
    if (document.querySelectorAll('#' + id + ' tbody tr').length < 6) {
        // чтобы при перелистывании месяцев не "подпрыгивала" вся страница, добавляется ряд пустых клеток. Итог: всегда 6 строк для цифр
        document.querySelector('#' + id + ' tbody').innerHTML += '<tr><td> <td> <td> <td> <td> <td> <td> ';
    }
}
calendar("calendar", new Date().getFullYear(), new Date().getMonth());
// переключатель минус месяц
document.querySelector('#calendar thead tr:nth-child(1) td:nth-child(1)').onclick = function () {
    calendar("calendar", document.querySelector('#calendar thead td:nth-child(2)').dataset.year, parseFloat(document.querySelector('#calendar thead td:nth-child(2)').dataset.month) - 1);
}
// переключатель плюс месяц
document.querySelector('#calendar thead tr:nth-child(1) td:nth-child(3)').onclick = function () {
    calendar("calendar", document.querySelector('#calendar thead td:nth-child(2)').dataset.year, parseFloat(document.querySelector('#calendar thead td:nth-child(2)').dataset.month) + 1);
}

var List = $('#tdlApp ul');
var Mask = 'tdl_';

function showTasks() {
    // Узнаём размер хранилища
    var Storage_size = localStorage.length;
    // Если в хранилище что-то есть…
    if (Storage_size > 0) {
        // то берём и добавляем это в задачи  
        for (var i = 0; i < Storage_size; i++) {
            var key = localStorage.key(i);
            if (key.indexOf(Mask) == 0) {
                // и делаем это элементами списка
                $('<li></li>').addClass('tdItem')
                    .attr('data-itemid', key)
                    .text(localStorage.getItem(key))
                    .appendTo(List);
            }
        }
    }
}

$('#tdlApp input').on('keydown', function (e) {
    if (e.keyCode != 13) return;
    var str = e.target.value;
    e.target.value = "";
    // Если в поле ввода было что-то написано — начинаем обрабатывать
    if (str.length > 0) {
        var number_Id = 0;
        List.children().each(function (index, el) {
            var element_Id = $(el).attr('data-itemid').slice(4);
            if (element_Id > number_Id)
                number_Id = element_Id;
        })
        number_Id++;
        // Отправляем новую задачу сразу в память
        localStorage.setItem(Mask + number_Id, str);
        // и добавляем её в конец списка
        $('<li></li>').addClass('tdItem')
            .attr('data-itemid', Mask + number_Id)
            .text(str).appendTo(List);
    }
});

$(document).on('click', '.tdItem', function (e) {
    // Находим задачу, по которой кликнули
    var jet = $(e.target);
    // Убираем её из памяти
    localStorage.removeItem(jet.attr('data-itemid'));
    // и убираем её из списка
    jet.remove();
})

//tables functions

function addTable() {
    var element = document.getElementById('table-1');
    var link = document.createElement('a');
    var br = document.createElement('br');

    link.innerHTML = 'Входящий трафик';

    /* link.className = 'btn btn-primary btn-page';*/
    /*    link.href = 'http//:google.com';*/
    link.href = 'IncomingTraffics/Index';

    element.appendChild(br);
    element.appendChild(link);
}

function inputValueTrue(id, id_lab) {
    var element = document.getElementById(id);
    var div_t = document.getElementById(id_lab);
    element.value = 'true';
    div_t.classList.remove('selected');
    div_t.classList.add('select_table');
}

function inputValueFalse(id, id_lab) {
    var element = document.getElementById(id);
    var div_t = document.getElementById(id_lab);
    element.value = 'false';
    div_t.classList.remove('select_table');
    div_t.classList.add('selected');
}

/* Калькулятор */

var keys = document.querySelectorAll('#calculator span');
var operators = ['+', '-', 'x', '÷'];
var decimalAdded = false;

for (var i = 0; i < keys.length; i++) {
    keys[i].onclick = function (e) {
        var input = document.querySelector('.screen');
        var inputVal = input.innerHTML;
        var btnVal = this.innerHTML;

        if (btnVal == 'C') {
            input.innerHTML = '';
            decimalAdded = false;
        }
        else if (btnVal == '=') {
            var equation = inputVal;
            var lastChar = equation[equation.length - 1];

            equation = equation.replace(/x/g, '*').replace(/÷/g, '/');
            if (operators.indexOf(lastChar) > -1 || lastChar == '.')
                equation = equation.replace(/.$/, '');

            if (equation)
                input.innerHTML = eval(equation);

            decimalAdded = false;
        }
        else if (operators.indexOf(btnVal) > -1) {
            var lastChar = inputVal[inputVal.length - 1];

            if (inputVal != '' && operators.indexOf(lastChar) == -1)
                input.innerHTML += btnVal;

            else if (inputVal == '' && btnVal == '-')
                input.innerHTML += btnVal;

            if (operators.indexOf(lastChar) > -1 && inputVal.length > 1) {
                input.innerHTML = inputVal.replace(/.$/, btnVal);
            }

            decimalAdded = false;
        }
        else if (btnVal == '.') {
            if (!decimalAdded) {
                input.innerHTML += btnVal;
                decimalAdded = true;
            }
        }
        else {
            input.innerHTML += btnVal;
        }

        e.preventDefault();
    }
}


