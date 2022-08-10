async function getUserById(id) {
    getData(`${BASE_API}api/Account/getinfo/${id}`)
        .then(response => {
            return response.data
        })
        .catch(error => {
            alert('There was an error when get user!', error)
        })
}

function requestLogin() {
    // case haven't login yet: alert and ask user to login
    if (!USERTOKEN) {
        /*$('#showModalLogin').click();*/
        window.location = '/User/LoginRequest';
    }
    else {
        // case token expire: alert and ask user to login again
        if (parseJwt(USERTOKEN).exp < new Date() / 1000) {
            window.location = '/User/LoginRequest';
        }
    }
}