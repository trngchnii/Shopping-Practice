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

  return (
    <>
      {" "}
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
    </>
  );
};

export default memo(HomePage);
