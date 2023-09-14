function updateRelativeTimes() {
    var relativeTimeElements = document.querySelectorAll('.relative-time');
    relativeTimeElements.forEach(function (element) {
        var dateToDisplay = element.getAttribute('data-date');
        var relativeTime = moment(dateToDisplay).fromNow();
        element.innerHTML = `<i class="fa-regular fa-calendar"></i>${relativeTime}`;
    });
}

updateRelativeTimes();

setInterval(updateRelativeTimes, 60000);
