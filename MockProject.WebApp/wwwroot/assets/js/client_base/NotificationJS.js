const notyf = new Notyf({
    duration: 4000,
    position: {
        x: 'right',
        y: 'top',
    },
    dismissible: true,
    riple: true
});
const notify = function (type, message) {
    if (type == "success") {
        notyf.success({
            message: message,
        })
    }
    if (type == "error") {
        notyf.error({
            message: message,
        })
    }
}