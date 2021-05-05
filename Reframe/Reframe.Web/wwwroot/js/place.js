
$("#place-submit").click(function(event){
    event.preventDefault();
  });

NameIsTakenLoading =false;
function send(){
    $.ajax({ 
        method: "POST",
         headers: { 
            'Accept': 'application/json',
        },
        contentType: "application/json; charset=utf-8",
        url: "https://localhost:44303/api/Place",
        dataType: "json",
        data:JSON.stringify({
           name: $('#Name').val(),
           numberOfDesk: $('#NumberOfDesk').val()
        })
    })
    .done(function( data, textStatus, jqXHR) {
        NameIsTakenLoading = false;
        $('#placeList').append( `
         <li id="${data.id}">
        <p>Name: ${data.name}</p>
        <p>Desk:${data.numberOfDesk}</p>
        <p>Created at: ${data.creationTime}</p>
    </li>` );
    })
    .fail(function( jqXHR, textstatus, errorTheown) {
        alert("Sikertelen felvétel");
    })

}
function checkIfTaken(){
    const name = $('#Name').val();
    console.log(name)
    NameIsTakenLoading = true;
    $.ajax({ method: "GET",url: "https://localhost:44303/api/Place/taken?searchText=" + name})
    .done(function( data, textStatus, jqXHR) {
        NameIsTakenLoading = false;
        if(data == true){

            $('#Name').next('P').remove()
            $('#Name').after('<p> -- </p>')
        }else{

            $('#Name').next('P').remove()
            $('#Name').after('<p> ++ </p>')
        }
    })
    .fail(function( jqXHR, textstatus, errorTheown) {
        NameIsTakenLoading = false;
        $('#Name').next('P').remove()
        $('#Name').after('<p> Error </p>')
    })
}