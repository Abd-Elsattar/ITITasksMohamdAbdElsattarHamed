function loadCart() {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    let cartItemsDiv = document.getElementById("cart-items");
    let totalDiv = document.getElementById("total");
    cartItemsDiv.innerHTML = "";
    let grandTotal = 0;

    cart.forEach((product, index) => {
        let row = document.createElement("tr");

        // Image
        let imgTd = document.createElement("td");
        let img = document.createElement("img");
        img.src = product.image;
        imgTd.appendChild(img);
        row.appendChild(imgTd);

        // Title && //descripton
        let titleTd = document.createElement("td");
        titleTd.innerHTML = `<div><b>${product.title}</b></div>`;
        row.appendChild(titleTd);

        

        // Price
        let priceTd = document.createElement("td");
        priceTd.innerText = `$${product.price}`;
        row.appendChild(priceTd);

        // Quantity
        let qtyTd = document.createElement("td");
        let decBtn = document.createElement("button");
        decBtn.innerText = "-";
        decBtn.classList.add("qty-btn");
        decBtn.onclick = () => updateQty(index, -1);

        let spanQty = document.createElement("span");
        spanQty.innerText = product.quantity;
        spanQty.style.margin = "0 10px";

        let incBtn = document.createElement("button");
        incBtn.innerText = "+";
        incBtn.classList.add("qty-btn");
        incBtn.onclick = () => updateQty(index, 1);

        qtyTd.appendChild(decBtn);
        qtyTd.appendChild(spanQty);
        qtyTd.appendChild(incBtn);
        row.appendChild(qtyTd);

        // Total per product
        let totalTd = document.createElement("td");
        let productTotal = product.price * product.quantity;
        totalTd.innerText = `$${productTotal.toFixed(2)}`;
        row.appendChild(totalTd);

        grandTotal += productTotal;

        // Remove button
        let removeTd = document.createElement("td");
        let removeBtn = document.createElement("button");
        removeBtn.innerText = "Remove";
        removeBtn.classList.add("remove-btn");
        removeBtn.onclick = () => removeFromCart(index);
        removeTd.appendChild(removeBtn);
        row.appendChild(removeTd);

        cartItemsDiv.appendChild(row);
    });

    totalDiv.innerText = `Total: $${grandTotal.toFixed(2)}`;
}

function updateQty(index, change) {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    if (cart[index].quantity + change > 0) {
        cart[index].quantity += change;
    }
    localStorage.setItem("cart", JSON.stringify(cart));
    loadCart();
}

function removeFromCart(index) {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    cart.splice(index, 1);
    localStorage.setItem("cart", JSON.stringify(cart));
    loadCart();
}

let btnContinue = document.getElementById("continuebtn");
btnContinue.classList.add("continuBtnClass")

btnContinue.addEventListener("click", function () {
    window.location.href = "Lab D03.html";
})

let btnPurchase = document.getElementById("orderbtn")
btnPurchase.classList.add("orderBtnClass")

btnPurchase.addEventListener("click",function purchase() {
    alert("منين يافقير ياغلبان !....");
    localStorage.removeItem("cart");
    loadCart();
})

loadCart();
