// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function onEmail(t) {
    // очищаем форму и ошибки
    document.getElementById('error').innerHTML = '';
    document.getElementById('message').innerHTML = '';
    // отправляем запрос на сервер и обрабатываем результат
    if (t.form.email.value != '') {
        fetch('https://htmlweb.ru/json/service/email?email=' + encodeURIComponent(t.form.email.value)
                                            /*+'&smtp_check&api_key=API_KEY_из_профиля'*/)
            .then(
                function (data) { // обрабатываем ответ от сервера
                    if (data.status !== 200) {
                        return Promise.reject(new Error(data.statusText));
                    }
                    return data.json(); // раскодируем json в объект
                })
            .then(
                function (data) {
                    console.log('data:', data);
                    var o;
                    for (var key in data) {
                        // заполняю поля формы по name или по id
                        if (key in t.form) t.form[key].value = data[key];
                        else {
                            o = document.getElementById(key);
                            if (o) o.innerHTML = data[key]
                        }
                    }
                })
            .catch(
                function (error) {
                    console.error(error)
                });
    }
}
