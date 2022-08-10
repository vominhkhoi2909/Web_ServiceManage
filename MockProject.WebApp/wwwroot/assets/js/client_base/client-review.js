// render reivew list by array
function renderReviewList(reviewArr) {
    let html = reviewArr.map((item,index) => {
        // set star 
        let starHtml = ''
        for (let i = 0; i < item.ratingScore; i++) {
            starHtml += `<i style="color: #FFDD44;font-size: 18px;" class="fa-solid fa-star"></i> `
        }
        for (let i = item.ratingScore; i < 5; i++) {
            starHtml += `<i style="font-size: 18px;" class="fa-solid fa-star"></i> `
        }
        // get time comment
        // case 2 nearest comment: show durition of time
        // case other: show date and hour
        let timeString = (index < 2) ? moment(item.createAt).fromNow() : moment(item.createAt).format('llll')
        return `
        <div class="comment mt-4 text-justify float-left">
            <img src="/assets/image/profileImg/${item.avatar}"
            alt="" class="rounded-circle" width="40" height="40">
            <h4 style="margin-left: 6px;">${item.fullName}</h4>
            <span> - ${timeString}</span>
            <div class="star__group">
                ${starHtml}
            </div>
            <br>
            <p>
                ${item.comment}
            </p>
        </div>
            `
    }).join('')

    $('.comment__list').html(html)
}

//fetch api get all review show all list
function renderReivew() {
    getData(`${BASE_API}api/Review/All`)
        .then(response => {
            renderReviewList(response.data)
        })
        .catch(error => {
            notify('error', 'get review have some problem!!')
        })
}
renderReivew()

// render error list by array
function renderError(error) {
    let html = error.map(item => {
        return `
                    <li class="review__error-item">${item}</li>
                `
    }).join('')

    $('.review__error-list').html(html);
}

//check user is login
function isValidLogin() {
    // case haven't login yet: alert and ask user to login
    if (!USERTOKEN) {
        renderError(['Please login to send review'])
        $('.review__error-list').append(`<a href="/User/login">Click here to Login<a>`);
        return false
    }
    else {
        // case token expire: alert and ask user to login again
        if (parseJwt(USERTOKEN).exp < new Date() / 1000) {
            renderError(['Your token is exprire, please login again to send review'])
            $('.review__error-list').append(`<a href="/User/login">Click here to Login<a>`);
            return false
        }
        return true
    }
}

// send reivew
$('#send-review-form').submit(async function (event) {
    event.preventDefault()
    // check if user login and token is not expired
    if (isValidLogin() == true) {
        // get data object
        // fetch user infomation by token
        let userLoginNow = await getDataWithToken(`${BASE_API}api/Account/getinfo`, USERTOKEN)
        let createBy = userLoginNow.data.userId
        let comment = $('#review-comment').val()
        let ratingScore = $("input[type='radio']:checked").val();
        let createAt = new Date()
        console.log(createAt)
        // check if user choose star when add review
        if (!ratingScore) {
            renderError(['Please choose number of star'])
            notify('error', 'send review fail, please check again')
            return;
        }
        let object = {
            comment, ratingScore, createAt, createBy
        }
        // fetch apit post add review
        postData(`${BASE_API}api/Review/Add`, object)
        .then(response => {
            // case success: show totify and clear input text
            if (response.success == true) {
                notify('success', 'send review success, thanks for your reivew')
                renderReivew()
                // clear form text
                $("#send-review-form")[0].reset();
                // clear err if have
                $('.review__error-list').html('');
            }
            // case error by identity: show error
            else if (!response.ok && response.errors != null) {
                renderError(Object.values(response.errors))
                notify('error', 'send review fail, please check again')
            }
            // case error: show error
            else {
                renderError(Object.values([response.message]))
                notify('error', 'send review fail, please check again')
            }
        })
    }
})
