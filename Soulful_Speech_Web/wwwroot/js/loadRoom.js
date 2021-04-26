
$(document).ready(function () {

	const hubConnection = new signalR.HubConnectionBuilder()
		.withUrl("/chat")
		.build();
	hubConnection.serverTimeoutInMilliseconds = 1000 * 60 * 10;
	hubConnection.start();

	$("#Rooms .TabItem").click(function (e) {
		e.preventDefault();
		var $this = $(this);
		$.ajax({
			type: "POST",
			url: "/Home/Index",
			dataType: "html",
			contentType: "application/json; charset=utf-8",
			success: function (result) {
				$("#Chat").load("/Home/OpenRoom", { roomId: $this.prop('id') });
				hubConnection.invoke("Disconnect");
				hubConnection.invoke("Join", $this.prop('id'));
			},
			error: function (error) {
				alert("There was an error posting the data to the server: " + error.responseText);
			}
		});
	});


	

	//$("#FoundRoomsResult").on('click','.FoundRoomTabItem',function (e) {
	//	e.preventDefault();
	//	console.log("haha2");
	//	var $this = $(this);
	//	$.ajax({
	//		type: "POST",
	//		url: "/Home/Index",
	//		dataType: "html",
	//		contentType: "application/json; charset=utf-8",
	//		success: function (result) {
				
	//			$("#Chat").load("/Home/OpenRoom", { roomId: $this.prop('id') });	

				
	//		},
	//		error: function (error) {
	//			alert("There was an error posting the data to the server: " + error.responseText);
	//		}
	//	});
	//});

	hubConnection.on("Send", function (message, userName, dateTime) {
		$("#MessageMonitor")
			.append('<div class="Message"><div><p class="Sender">' + userName + '</p>' + message + '<b class="Indentation"></b><p class="MessageTime">' + dateTime + '</p></div></div>');
	});


	$('#sendMessageForm').submit(function (e) {

		e.preventDefault();
		let userMessageTB = document.getElementsByName("UserMessageTB")[0];
		console.log(userMessageTB.getAttribute('id'));
		console.log(userMessageTB.value);
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
			},
			error: function (error) {
				alert("There was an error posting the data to the server: " + error.responseText);
			}
		});

		return false;
	});

	
});
