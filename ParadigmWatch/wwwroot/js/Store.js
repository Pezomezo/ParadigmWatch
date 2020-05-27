
// This has the same functionality as the one inside the Main.js

let sortOrder = document.getElementById('sortOrder');
let oddClick = false;
sortOrder.addEventListener('click', () => {
    let theUrl = window.location.href.split("/")
    if (oddClick) {


        if (theUrl[theUrl.length - 1] == "Store") {
            let order = sortOrder.options[sortOrder.selectedIndex].value.toString().substring(0, 1);
            let productList = document.getElementsByClassName('storeProducts').item(0)
            if (order == 'Z') {
                productList.style.flexDirection = "column-reverse";
            } else {
                productList.style.flexDirection = "column";
            }
            oddClick = false;
        } else {
            let order = sortOrder.options[sortOrder.selectedIndex].value.toString().substring(0, 1);
            let productList = document.getElementsByClassName('products').item(0)
            if (order == 'Z') {
                productList.style.flexDirection = "row-reverse";
            } else {
                productList.style.flexDirection = "row";
            }
            oddClick = false;
        }

    } else {
        oddClick = true;
    }
})

let redirectToStore = document.getElementById('ColumnViewID')
redirectToStore.addEventListener('click', () => {
    let theUrl = window.location.href.split("/")
    let returnUrl = `${theUrl[0]}//${theUrl[2]}/Store`
    if (!(returnUrl == window.location.href)) {
        window.location.href = returnUrl;
    }
})


let redirectToHome = document.getElementById('GridViewID')
redirectToHome.addEventListener('click', () => {
    let theUrl = window.location.href.split("/")
    let returnUrl = `${theUrl[0]}//${theUrl[2]}`
    if (!(returnUrl == window.location.href)) {
        window.location.href = returnUrl;
    }
})