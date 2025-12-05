import { memo } from "react";
import Carousel from "react-multi-carousel";
import "react-multi-carousel/lib/styles.css";
import "../homePage/style.scss";
import "../../../styles/style.scss";
import item1Img from "../../../asset/users/images/categories/item1.jpg";
import item2Img from "../../../asset/users/images/categories/item2.jpg";
import item3Img from "../../../asset/users/images/categories/item3.jpg";
import item4Img from "../../../asset/users/images/categories/item4.jpg";
import item5Img from "../../../asset/users/images/categories/item5.jpeg";
import item6Img from "../../../asset/users/images/categories/item6.jpg";
import { Tab, TabList, TabPanel, Tabs } from "react-tabs";
import { AiOutlineEye, AiOutlineShoppingCart } from "react-icons/ai";
import { formatter } from "../../../utils/formatter";
import { Link } from "react-router-dom";
const HomePage = () => {
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

  const sliderItems = [
    {
      bgImg: item1Img,
      name: "CRYBABY × Powerpuff Girls Series Figures",
    },
    {
      bgImg: item2Img,
      name: "SKULLPANDA The Warmth Series",
    },
    {
      bgImg: item3Img,
      name: "MOLLY × Zootopia Co-branded Series Figures",
    },
    {
      bgImg: item4Img,
      name: "Celebrating the Moment POP MART 15th Anniversary Series Figures",
    },
    {
      bgImg: item5Img,
      name: "Babythree v3 mini",
    },
    {
      bgImg: item6Img,
      name: "Babythree Lucky cat v1",
    },
  ];

  const newArrivals = {
    all: {
      title: "All",
      products: [
        {
          img: item1Img,
          name: "Babythree",
          price: 200,
        },
        {
          img: item2Img,
          name: "Popmart",
          price: 200,
        },
        {
          img: item2Img,
          name: "Popmart",
          price: 200,
        },
        {
          img: item2Img,
          name: "Popmart",
          price: 200,
        },
        {
          img: item2Img,
          name: "Popmart",
          price: 200,
        },
      ],
    },
    popmart: {
      title: "Popmart",
      products: [
        {
          img: item2Img,
          name: "Popmart",
          price: 200,
        },
      ],
    },
  };

  const renderNewArrivals = (data) => {
    const tabList = [];
    const tabPanels = [];

    Object.keys(data).forEach((key, index) => {
      // create Tab
      tabList.push(<Tab key={key}>{data[key].title}</Tab>);

      // create TabPanel
      tabPanels.push(
        <TabPanel key={key}>
          <div className="row">
            {data[key].products.map((item, j) => (
              <div
                className="col-xl-3 col-lg-3 col-md-6 col-sm-6 col-xs-12"
                key={j}
              >
                <div className="new_arrivals__item">
                  <div
                    className="new_arrivals__item__pic"
                    style={{ backgroundImage: `url(${item.img})` }}
                  >
                    <ul className="new_arrivals__item__pic_hover">
                      <li>
                        <AiOutlineEye />
                      </li>
                      <li>
                        <AiOutlineShoppingCart />
                      </li>
                    </ul>
                  </div>
                  <div className="new_arrivals__item__text">
                    <h6>
                      <Link to="">{item.name}</Link>
                    </h6>
                    <h5>{formatter(item.price)}</h5>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </TabPanel>
      );
    });

    return (
      <Tabs>
        <TabList>{tabList}</TabList>
        {tabPanels}
      </Tabs>
    );
  };
  // thêm dữ liệu recommend
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

  return (
    <>
      <div className="container container__categories_slider">
        <Carousel responsive={responsive} className="categories_slider">
          {sliderItems.map((item, key) => (
            <div
              className="categories_slider_item"
              style={{ backgroundImage: `url(${item.bgImg})` }}
              key={key}
            >
              <p>{item.name}</p>
            </div>
          ))}
        </Carousel>
      </div>

      <div className="container">
        <div className="new-arrivals">
          <div className="section-title">
            <h2>NEW ARRIVALS</h2>
          </div>
          {renderNewArrivals(newArrivals)}
        </div>
      </div>

      {/* Recommend For You */}
      <div className="container">
        <div className="recommend">
          <div className="section-title">
            <h2>RECOMMEND FOR YOU</h2>
          </div>
          <Carousel responsive={responsive} className="recommend_slider">
            {recommendItems.map((item, idx) => (
              <div className="recommend_item" key={idx}>
                <div
                  className="recommend_item_pic"
                  style={{ backgroundImage: `url(${item.img})` }}
                >
                  <ul className="recommend_item_hover">
                    <li>
                      <AiOutlineEye />
                    </li>
                    <li>
                      <AiOutlineShoppingCart />
                    </li>
                  </ul>
                </div>
                <div className="recommend_item_text">
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
    </>
  );
};

export default memo(HomePage);
