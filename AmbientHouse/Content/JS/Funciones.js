function showErrorMessage(errorMessage) {
    $('#ModalValidation').modal('show');
    $('#ModalValidation .modal-body p').html(errorMessage);
    $("#ModalValidation .modal-body p").css("color", "red");
}
//showErrorMessage($(this).prev().html()); //get prev elements htmls 