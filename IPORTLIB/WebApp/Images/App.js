$(function () {
	
	// set old data
	$("#btnUpload").click(function () {
		$("#OldAttachmentId").val($("#AttachmentId").val());
		$("#OldSrcImage").val($("#resultImage").attr("src"));
	});

	// upload file with choose file on PC
	$("#chooseDevice").change(function () {
		var file = $(this)[0].files[0];
		if (file !== null && file !== '') {
			var data = new FormData();
			data.append('file', file);
			$.ajax({
				contentType: "application/x-www-form-urlencoded, multipart/form-data",
				url: "/Attachment/Upload",
				processData: false, // tell jQuery not to process the data
				contentType: false, // tell jQuery not to set contentType
				type: "POST",
				data: data
			}).success(function (dataResponsive) {
				$("#ChoosedImage").attr("src", "/Uploads/" + dataResponsive.Url);
				$("#tmpAttachmentId").val(dataResponsive.AttachmentId);
				$("#txtUrl").attr("disabled", true);
				$("#chooseUrl").attr("disabled", true);
			});
		}
	});

	// click ok save image
	$("#readyImage").click(function () {
		if ($("#ChoosedImage").attr("src") !== "" && $("#tmpAttachmentId").val() !== "") {
			$("#AttachmentId").val($("#tmpAttachmentId").val());
			$("#resultImage").attr("src", $("#ChoosedImage").attr("src"));
		}
	});

	// cancel file upload
	$(".cancelImage").click(function () {
		$("#AttachmentId").val($("#OldAttachmentId").val());
		$("#resultImage").val($("#OldSrcImage").val());
	});

	// upload file from Url
	$("#chooseUrl").click(function () {
		var txtUrl = $("#txtUrl").val();
		if (txtUrl !== "") {
			var data = { Url: txtUrl };
			$.ajax({
				url: "/Attachment/UploadFromUrl",
				type: "POST",
				dataType: 'json',
				data: data
			}).success(function (dataResponsive) {
				$("#ChoosedImage").attr("src", "/Uploads/" + dataResponsive.Url);
				$("#tmpAttachmentId").val(dataResponsive.AttachmentId);
				$("#chooseDevice").attr("disabled", true);
			});
		}
	});
});