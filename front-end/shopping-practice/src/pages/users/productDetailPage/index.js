import { memo, useState } from "react";
import Breadcrumb from "../theme/breadcrumb";
import "../productDetailPage/style.scss";
import item3Img from "../../../asset/users/images/categories/item3.jpg";
import item4Img from "../../../asset/users/images/categories/item4.jpg";
import item6Img from "../../../asset/users/images/categories/item6.jpg";
import item5Img from "../../../asset/users/images/categories/item5.jpeg";
import {
  AiOutlineCopy,
  AiOutlineEye,
  AiOutlineFacebook,
  AiOutlineHeart,
  AiOutlineInstagram,
  AiOutlineLinkedin,
  AiOutlineShoppingCart,
} from "react-icons/ai";
import { formatter } from "../../../utils/formatter";
import Carousel from "react-multi-carousel";
import { Link } from "react-router-dom";
const ProductDetailPage = () => {
  const responsive = {
    superLargeDesktop: {
      breakpoint: { max: 4000, min: 3000 },
      items: 5,
    },
    desktop: {
      breakpoint: { max: 3000, min: 1024 },
      items: 4,
    },
    tablet: {
      breakpoint: { max: 1024, min: 464 },
      items: 2,
    },
    mobile: {
      breakpoint: { max: 464, min: 0 },
      items: 1,
    },
  };

  const imgs = [item3Img, item4Img, item5Img];

  const recommendItems = [
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
  const [selected, setSelected] = useState("whole");

  return (
    <>
      <Breadcrumb name="THE MONSTERS 1:00 A.M. Series" />
      <div className="container container_productDetail">
        <div className="row">
          <div className="col-6 product__detail__pic">
            <img src={item3Img} alt="THE MONSTERS figure" />
            <div className="main">
              {imgs.map((item, key) => (
                <img src={item} alt={`monster-${key}`} key={key} />
              ))}
            </div>
          </div>
          <div className="col-6 product__detail__text">
            <h2>THE MONSTERS 1:00 A.M.</h2>
            <div className="seen_icon">
              <AiOutlineEye />
              {`102 (views)`}
            </div>
            <h3>{formatter(209.9)}</h3>
            <div className="product_size_selector">
              <h4>SIZE</h4>
              <div className="size_options">
                <div
                  className={`size_option ${
                    selected === "single" ? "active" : ""
                  }`}
                  onClick={() => setSelected("single")}
                >
                  <img src={item3Img} alt="Single box" />
                  <span>Single box</span>
                </div>
                <div
                  className={`size_option ${
                    selected === "whole" ? "active" : ""
                  }`}
                  onClick={() => setSelected("whole")}
                >
                  <img src={item4Img} alt="Whole set" />
                  <span>Whole set</span>
                </div>
              </div>
            </div>
            <p>
              Brand: POP MART
              <br />
              Online Release: November 13, 2025
              <br />
              Size: 5.4–10.6cm / 2.13–4.17inches
              <br />
              Material: PVC / ABS / Electronic Component
              <br />
              Not suitable for persons under 15.
              <br />
              *Due to differences in measurement methods, the actual
              measurements may vary.
            </p>
            <div className="product_actions">
              <button className="btn_favorite">
                <AiOutlineHeart />
                Favorite
              </button>
              <button className="btn_add_to_bag">ADD TO BAG</button>
            </div>

            <ul>
              <li>
                <b>Status: </b> <span>In Stock</span>
              </li>
              <li>
                <b>Quantity: </b> <span>12</span>
              </li>
              <li>
                <b>Share: </b>
                <span>
                  <AiOutlineFacebook />
                  <AiOutlineInstagram />
                  <AiOutlineLinkedin />
                  <AiOutlineCopy />
                </span>
              </li>
            </ul>
          </div>
        </div>

        <div className="product__detail__tab">
          <h4>Product Detail</h4>
          <div>
            <p>
              1. Single box: For individual boxes, because this is a random
              blindbox, the buyer will not be able to determine what is inside,
              but when buying multiple products on the same order, there will be
              no duplicate models, there is a chance of opening SECRET
            </p>
            <br />

            <p>
              {" "}
              2. Whole box: For the whole set (no duplicate), there is a chance
              of opening SECRET{" "}
            </p>
            <br />

            <p>
              SECRET is a rare model (the hidden model is blurred or blacked out
              on the box)
            </p>
            <br />
            <p>→ CUSTOMER SERVICE:</p>
            <br />

            <p>
              For any after-sales questions, please contact customer service
            </p>
            <br />

            <p>
              Due to different measurement methods, the measurement results will
              have an error of 1-3cm, within the normal range Due to the
              influence of light, display screen, camera and other factors
              otherwise, the image will be slightly different from the real
              object. The image size is for reference only{" "}
            </p>
            <br />
          </div>
        </div>

        <div className="container">
          <div className="similar-products">
            <div className="section-title">
              <h2>YOU MAY ALSO LIKE</h2>
            </div>
            <Carousel
              responsive={responsive}
              className="similar_products_slider"
            >
              {recommendItems.map((item, idx) => (
                <div className="similar_item" key={idx}>
                  <div
                    className="similar_item_pic"
                    style={{ backgroundImage: `url(${item.img})` }}
                  >
                    <ul className="similar_item_hover">
                      <li>
                        <AiOutlineEye />
                      </li>
                      <li>
                        <AiOutlineShoppingCart />
                      </li>
                    </ul>
                  </div>
                  <div className="similar_item_text">
                    <h6>
                      <Link to="">{item.name}</Link>
                    </h6>
                    <h5>{formatter(item.price)}</h5>
                  </div>
                </div>
              ))}
            </Carousel>
          </div>
        </div>
      </div>
    </>
  );
};

export default memo(ProductDetailPage);
