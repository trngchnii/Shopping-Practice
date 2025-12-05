import { memo } from "react";
import Breadcrumb from "../theme/breadcrumb";
import "../productsPage/style.scss";
import { generatePath, Link } from "react-router-dom";
import { ROUTERS } from "../../../utils/router";
import item3Img from "../../../asset/users/images/categories/item3.jpg";
import item4Img from "../../../asset/users/images/categories/item4.jpg";
import item5Img from "../../../asset/users/images/categories/item5.jpeg";
import item6Img from "../../../asset/users/images/categories/item6.jpg";
import { AiOutlineEye, AiOutlineShoppingCart } from "react-icons/ai";
import { formatter } from "../../../utils/formatter";
const ProductsPage = () => {
  const categories = ["All Products", "Babythree", "Popmart", "Lila zoo"];
  const productItems = [
    {
      img: item3Img,
      name: "MOLLY × Zootopia Co-branded Series",
      price: 180,
    },
    {
      img: item4Img,
      name: "POP MART 15th Anniversary Series",
      price: 220,
    },
    {
      img: item5Img,
      name: "Babythree v3 mini",
      price: 150,
    },
    {
      img: item6Img,
      name: "Babythree Lucky cat v1",
      price: 170,
    },
  ];
  return (
    <>
      <Breadcrumb name="List Product" />
      <div className="container_products">
        <div className="row">
          <div className="col-xl-3 col-lg-3 col-md-3 col-sm-3 col-xs-12">
            <div className="slidebar">
              <div className="slidebar__item">
                <h2>Category</h2>
                <ul>
                  {categories.map((item, key) => (
                    <li key={key}>
                      <Link to={ROUTERS.USER.PRODUCTS}>{item}</Link>
                    </li>
                  ))}
                </ul>
              </div>
            </div>
          </div>
          <div className="col-xl-9 col-lg-9 col-md-9 col-sm-9 col-xs-12">
            <div className="product_list">
              {productItems.map((item, idx) => (
                <div className="product_item" key={idx}>
                  <div
                    className="product_item_pic"
                    style={{ backgroundImage: `url(${item.img})` }}
                  >
                    <ul className="product_item_hover">
                      <li>
                        <AiOutlineEye />
                      </li>
                      <li>
                        <AiOutlineShoppingCart />
                      </li>
                    </ul>
                  </div>
                  <div className="product_item_text">
                    <h6>
                      <Link to={generatePath(ROUTERS.USER.PRODUCT, { id: 1 })}>
                        {item.name}
                      </Link>
                    </h6>
                    <h5>{formatter(item.price)}</h5>
                  </div>
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default memo(ProductsPage);
