import { memo, useState } from "react";
import "./style.scss";
import {
  AiOutlineFacebook,
  AiOutlineInstagram,
  AiOutlineLinkedin,
  AiOutlineMail,
  AiOutlinePhone,
  AiOutlineShoppingCart,
  AiOutlineUser,
} from "react-icons/ai";
import { Link } from "react-router-dom";
import { formatter } from "../../../../utils/formatter";
import { ROUTERS } from "../../../../utils/router";
const Header = () => {
  const [menus] = useState([
    {
      name: "Home",
      path: ROUTERS.USER.HOME,
    },
    {
      name: "Products",
      path: ROUTERS.USER.PRODUCTS,
      isShowSubmenu: false,
      child: [
        {
          name: "Babythree",
          path: "",
        },
        {
          name: "Popmart",
          path: "",
        },
        {
          name: "Others",
          path: "",
        },
      ],
    },
    {
      name: "About Us",
      path: ROUTERS.USER.ABOUTUS,
    },
    {
      name: "Contact",
      path: ROUTERS.USER.CONTACT,
    },
  ]);
  return (
    <>
      <div className="header__top">
        <div className="container">
          <div className="row">
            <div className="col-6 header__top_left">
              <ul>
                <li>
                  <AiOutlineMail />
                  ni.tnh04@gmail.com
                </li>
                <li>Freeship &lt; 3km</li>
              </ul>
            </div>
            <div className="col-6 header__top_right">
              <ul>
                <li>
                  <Link to="">
                    <AiOutlineFacebook />
                  </Link>
                </li>
                <li>
                  <Link to="">
                    <AiOutlineInstagram />
                  </Link>
                </li>
                <li>
                  <Link to="">
                    <AiOutlineLinkedin />
                  </Link>
                </li>

                <li>
                  <Link to="">
                    <AiOutlineUser />
                  </Link>
                  <span>Login</span>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
      <div className="container">
        <div className="row">
          <div className="col-xl-3 col-lg-3 col-md-3 col-sm-3">
            <div className="header__logo">
              <h1>Nina Shop</h1>
            </div>
          </div>
          <div className="col-xl-6 col-lg-6 col-md-6 col-sm-6">
            <nav className="header__menu">
              <ul>
                {menus?.map((menu, menuKey) => (
                  <li key={menuKey} className={menuKey === 0 ? "active" : ""}>
                    <Link to={menu?.path}>{menu?.name}</Link>
                    {menu.child && (
                      <ul className="header_menu_dropdown">
                        {menu.child.map((childItem, childKey) => (
                          <li key={`${menuKey} - ${childKey}`}>
                            <Link to={childItem.path}>{childItem.name}</Link>
                          </li>
                        ))}
                      </ul>
                    )}
                  </li>
                ))}
              </ul>
            </nav>
          </div>
          <div className="col-xl-3 col-lg-3 col-md-3 col-sm-3">
            <div className="header__cart">
              <div className="header__cart__price">
                <span>{formatter(100)}</span>
              </div>
              <ul>
                <li>
                  <Link to="#">
                    <AiOutlineShoppingCart />

                    <span>5</span>
                  </Link>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
      <div className="container">
        <div className="row hero__search">
          <div className="col-xl-9 col-lg-9 col-md-9 col-sm-9 hero_search_form">
            <form>
              <input type="text" placeholder="Enter keywords to search…" />
              <button type="submit">Search</button>
            </form>
          </div>
          <div className="col-xl-3 col-lg-3 col-md-3 col-sm-3 hero__search__phone">
            <div className="hero__search__phone__icon">
              <AiOutlinePhone />
            </div>
            <div className="hero__search__phone__text">
              <p>070.5355.331</p>
              <span>Support Available 24/7</span>
            </div>
          </div>
        </div>
        <div className="hero__item">
          <div className="hero__text">
            <span>Blindbox</span>
            <h2>Babythree - Popmart</h2>
            <p>Free home delivery</p>
            <Link to="" className="primary-btn">
              Buy now
            </Link>
          </div>
        </div>
      </div>
    </>
  );
};

export default memo(Header);
