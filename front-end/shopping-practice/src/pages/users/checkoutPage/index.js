import { memo } from "react";
import Breadcrumb from "../theme/breadcrumb";
import { formatter } from "../../../utils/formatter";
import "./style.scss";
const CheckoutPage = () => {
  return (
    <>
      <Breadcrumb name="Checkout" />
      <div className="container">
        <div className="row">
          <div className="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-xs-12 checkout">
            <div className="checkout__confirm">
              <div className="checkout__input">
                <label>
                  Your name: <span className="required">*</span>
                  <input type="text" placeholder="Enter your name" />
                </label>
              </div>
              <div className="checkout__input">
                <label>
                  Address: <span className="required">*</span>
                  <input type="text" placeholder="Enter your address" />
                </label>
              </div>
              <div className="checkout__input__group">
                <div className="checkout__input">
                  <label>
                    Phone: <span className="required">*</span>
                    <input type="text" placeholder="Enter your phone number" />
                  </label>
                </div>
                <div className="checkout__input">
                  <label>
                    Email: <span className="required">*</span>
                    <input type="text" placeholder="Enter your email" />
                  </label>
                </div>
              </div>
              <div className="checkout__input">
                <label>Notes:</label>
                <textarea rows={15} placeholder="Enter your notes" />
              </div>
            </div>
          </div>
          <div className="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-xs-12 checkout">
            <div className="checkout__order">
              <h3>Your Order</h3>
              <ul>
                <li>
                  <span>Product 1</span>
                  <b>{formatter(100)}</b>
                </li>
                <li>
                  <span>Product 2</span>
                  <b>{formatter(300)}</b>
                </li>
                <li>
                  <h4>Coupon</h4>
                  <b>SVC783</b>
                </li>
                <li className="checkout__order__subtotal">
                  {" "}
                  <h3>Total order</h3>
                  <b>{formatter(20000)}</b>
                </li>
              </ul>
              <button type="button" className="button-submit">
                PROCEED TO PAY
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default memo(CheckoutPage);
