//     fetch('https://fakestoreapi.com/products')
// as given this end point do the following points 
// 1- fetch data from this end point 
// 2- list these products in produts page

// 3- each product has add to cart button , image , prod title

// 4- while adding to cart redirect to cart page

// 5- list products added to cart with quantity and price

// 6- increase or decrease quantity and reflect it to price

// 7-if user purchase cart alert that cart purchased

// 8- u can remove element form cart after adding

// 9- button in cart continue shopping return to products page

// 10 if user added same product in producta page more than one it increase quantity in cart not add it as new item  


async function getData() {
    let res = await fetch("https://fakestoreapi.com/products");
    let products = await res.json();

    let myDiv = document.getElementById("products");
    myDiv.innerHTML = "";

    products.forEach(product => {

        // content for every single product
        let content = document.createElement("div");
        content.classList.add("products_content")

        //image for every single product
        let img = document.createElement("img");
        img.src = product.image;
        img.alit = product.title;

        // title for every single product
        let title = document.createElement("h3");
        title.innerText = product.title;

        //pragraph for price for every single product
        let price = document.createElement("p");
        price.innerText = `$${product.price}`;
        price.classList.add("priceClass")
        //discription for every single product
        let description = document.createElement("p")
        description.innerText = product.description
        description.classList.add("descriptionClass")

        // button add to card for every single product
        let btnAdd = document.createElement("button");
        btnAdd.innerText = "Add To Card";

        // routing to another page 
        btnAdd.addEventListener("click", function () {
            let cart = JSON.parse(localStorage.getItem("cart")) || [];


            // نشوف المنتج موجود قبل كده ولا لأ
            let existingProduct = cart.find(p => p.id === product.id);

            if (existingProduct) {
                // نزود الكمية
                existingProduct.quantity += 1;
            } else {
                // أول مرة يضاف → نحط quantity = 1
                cart.push({ ...product, quantity: 1 });
            }

            // نخزن تاني
            localStorage.setItem("cart", JSON.stringify(cart));

            // بعد الإضافة ممكن كمان نعمل redirect للـ cart.html
            window.location.href = "Lab D03 Page02.html";
        })

        // append all above about every product
        content.appendChild(img);
        content.appendChild(title);
        content.appendChild(description)
        content.appendChild(price);
        content.appendChild(btnAdd);

        myDiv.appendChild(content)
    });
}
getData();


