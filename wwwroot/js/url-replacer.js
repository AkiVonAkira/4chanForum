var paragraphs = document.getElementsByTagName('p');

for (var i = 0; i < paragraphs.length; i++) {
    var paragraph = paragraphs[i];
    paragraph.innerHTML = paragraph.innerHTML.replace(
        /https:\/\/\S+/g,
        function (match) {
            return '<a href="' + match + '">' + match + '</a>';
        }
    );
}