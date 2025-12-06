import { memo } from "react";
import Breadcrumb from "../theme/breadcrumb";
import "./style.scss";
import { formatter } from "../../../utils/formatter";
import { Quantity } from "../../../components";
import { AiOutlineClose } from "react-icons/ai";
const ShoppingCartPage = () => {
  return (
    <>
      <Breadcrumb name="Cart" />
      <div className="container">
        <div className="table__cart">
          <table>
            <thead>
              <tr>
                <th>Product</th>
                <th>Unit Price</th>
                <th>Quantity</th>
                <th>Total Price</th>
                <th />
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>
                  <img
                    src="https://bizweb.dktcdn.net/thumb/1024x1024/100/515/274/products/63-e3e6116f-615f-489a-9f43-d1e857b5db6c.jpg?v=1763207189597"
                    alt="product-pic"
                  />
                  <h4>Product 1</h4>
                </td>
                <td>{formatter(200)}</td>
                <td>
                  <Quantity quantity="2" hasAddToCart={false} />
                </td>
                <td>{formatter(433300)}</td>
                <td className="icon_close">
                  <AiOutlineClose />
                </td>
              </tr>
            </tbody>
          </table>
        </div>
        <div className="row">
          <div className="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-xs-12">
            <div className="shopping__continue">
              <h3>Coupon</h3>
              <div className="shopping__discount">
                <input type="text" placeholder="Please enter the coupon code" />
                <button type="submit" className="button-submit">
                  Apply
                </button>
              </div>
            </div>
          </div>
          <div className="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-xs-12">
            <div className="shopping__checkout">
              <h2>{"Total (1 item)"} </h2>
              <ul>
                <li>
                  Amout: <span>{2}</span>
                </li>
                <li>
                  Total Price: <span>{formatter(20000)}</span>
                </li>
              </ul>
              <button type="submit" className="button-submit">
                Checkout
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default memo(ShoppingCartPage);
