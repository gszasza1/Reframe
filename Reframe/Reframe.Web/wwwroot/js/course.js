
function getCourses() {
    $.ajax({ method: "GET", url: "https://localhost:44303/api/Course"  })
        .done(function (data) {
            if (data.length) {
                console.log(data)
                data.forEach(element => {
                $('#course-list').append(
                    `<li class="list-group-item">
                    <p>Creator: <b>${element.creator}</b></p>
                    <p>Description:<b> ${element.description}</b></p>
                    <p>Place: <b>${element.placeName}</b></p>
                    <p>Subject: <b>${element.subjectName}</b></p>
                    <p>Title:<b> ${element.title}</b></p>
                    <p>Time:<b> ${element.time}</b></p>
                </li>`
                )
                });
            }
        })
        .fail(function (jqXHR, textstatus, errorTheown) {
        })
}
getCourses();
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/CourseHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(start);

// Start the connection.
start();
connection.on("AddCourse", (data) => {

    $('#course-list').append(
        `<li class="list-group-item">
                    <p>Creator:<b> ${data.creator}</b></p>
                    <p>Description:<b> ${data.description}</b></p>
                    <p>Place:<b> ${data.placeName}</b></p>
                    <p>Subject:<b> ${data.subjectName}</b></p>
                    <p>Title:<b> ${data.title}</b></p>
                    <p>Time:<b> ${data.time}</b></p>
                </li>`
    )
});
