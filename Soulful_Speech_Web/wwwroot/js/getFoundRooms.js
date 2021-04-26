
$(document).ready(function () {

	const searchingForm = document.getElementById('SearchRoomForm');

	var typingTimer; 
	var doneTypingInterval = 500;  
	var $input = $('#SearchRoomForm');

	$input.on('keyup', function () {
		clearTimeout(typingTimer);
		typingTimer = setTimeout(getRooms, doneTypingInterval);
	});

	$input.on('keydown', function () {
		clearTimeout(typingTimer);
	});

	function getRooms() {
		$.ajax({
			type: "Get",//Post???
			url: "/Home/GetFoundRooms",
			dataType: "html",
			data: $("#SearchRoomForm").serialize(),
			//data: {
			//	Name: $('#DesiredRoomName').val(),
			//	Tags: $('#DesiredRoomTags').val()
			//},
			contentType: "application/json; charset=utf-8",
			success: function (result) {
				//$("#SearchRoom").append(result);
				
				document.getElementById("FoundRoomsResult").innerHTML = result;

				$('#AddRoomURL').bind('click', function (roomId) {
					console.log($(this).closest('.FoundRoomTabItem').attr('id'));
					$.post("/Home/AddRoom", { roomId: $(this).closest('.FoundRoomTabItem').attr('id') });
					
				});
			},
			error: function (error) {
				alert("There was an error posting the data to the server: " + error.responseText);
			}
		});
	}

});

