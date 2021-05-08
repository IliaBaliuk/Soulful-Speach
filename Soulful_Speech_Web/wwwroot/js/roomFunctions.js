
$(document).ready(function () {

	const hubConnection = new signalR.HubConnectionBuilder()
		.withUrl("/chat")
		.build();
	hubConnection.serverTimeoutInMilliseconds = 1000 * 60 * 10;
	hubConnection.start();

	$("#Rooms .TabItem").click(function (e) {
		e.preventDefault();
		var $this = $(this);	
		$.post("/Home/OpenRoom", { roomId: $this.prop('id') }, function (result) {
			$("#Chat").html(result);
			$('.MessageMonitor').scrollTop(10000);
			hubConnection.invoke("Disconnect");
			hubConnection.invoke("Join", $this.prop('id'));
		});
	});

	$("#FoundRoomsResult").on('click','.FoundRoomTabItem',function (e) {
		e.preventDefault();
		var $this = $(this);
		$.post("/Home/OpenRoom", { roomId: $this.prop('id') }, function (result) {
			$("#Chat").html(result);
			$('.MessageMonitor').scrollTop(10000);
			hubConnection.invoke("Disconnect");
			hubConnection.invoke("Join", $this.prop('id'));
		});
	});

	hubConnection.on("Send", function (message, userName, dateTime) {
		$(".MessageMonitor")
			.append('<div class="Message"><div><p class="Sender">' + userName + '</p>' + message + '<b class="Indentation"></b><p class="MessageTime">' + dateTime + '</p></div></div>');
	});

	$('#sendMessageForm').submit(function (e) {

		e.preventDefault();
		let userMessageTB = document.getElementsByName("UserMessageTB")[0];
		$.ajax({
			type: "Get",
			url: "/Home/SendMessage",
			data: {
				roomId: userMessageTB.getAttribute('id'),
				message: userMessageTB.value
			},
			dataType: "JSON",
			contentType: "application/json; charset=utf-8",
			success: function (result) {	
				hubConnection.invoke("Send", result.message, result.userName, result.dateTime);
				$('.MessageMonitor').scrollTop(100000);
			},
			error: function (error) {
				alert("There was an error posting the data to the server: " + error.responseText);
			}
		});
		return false;
	});

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

				document.getElementById("FoundRoomsResult").innerHTML = result;

				$('#AddRoomURL').bind('click', function (roomId) {
					$.post("/Home/AddRoom", { roomId: $(this).closest('.FoundRoomTabItem').attr('id') });
					location.reload();
				});
			},
			error: function (error) {
				alert("There was an error posting the data to the server: " + error.responseText);
			}
		});
	}

	$(".MessageMonitor").scroll(function () {
		if ($(".MessageMonitor").scrollTop() == 0) {
			let $this = $(this);
			$.post("/Home/GetMoreMessages", { roomId: $this.prop('id') }, function (result) {
				$(".MessageMonitor").prepend(result);
				if (result != "") {
					$('.MessageMonitor').scrollTop(100);
                }
				
			});
			
		}
	})
});
