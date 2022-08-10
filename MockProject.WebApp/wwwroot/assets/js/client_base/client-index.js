// about us place
//fetch api get about us infomation and render
function renderAboutUs() {
    getData(`${BASE_API}api/Option/Type/9`)
        .then(response => {
            $('#about-us-title').html(response.data[0].title)
            $('#about-us-description').html(`<p>${response.data[0].description}</p>`)
        })
        .catch(error => {
            notify('error', 'There was an error when render about us!')
        })
}
renderAboutUs()

// ================================================
// contact place
// render error list by array
function renderError(error) {
    let html = error.map(item => {
        return `
                    <li class="contact__error-item">${item}</li>
                `
    }).join('')

    $('.contact__error-list').html(html);
}

// send contact
$('#send-contact-form').submit(function (event) {
    event.preventDefault()
    // get object data from form by name
    const data = new FormData(event.target);
    const formContactDataObject = Object.fromEntries(data.entries());

    // fetch apit post contact
    postData(`${BASE_API}api/Contact/Add`, formContactDataObject)
        .then(response => {
            // case success: show totify and clear input text
            if (response.success == true) {
                notify('success', 'send contact success, we will contact you soon')
                // clear form text
                $("#send-contact-form")[0].reset();
                // clear err if have
                $('.contact__error-list').html('');
            }
            // case error by identity: show error
            else if (!response.ok && response.errors != null) {
                renderError(Object.values(response.errors))
            }

            // case error: show error
            else {
                renderError(Object.values([response.message]))
            }
        })
})

// 


