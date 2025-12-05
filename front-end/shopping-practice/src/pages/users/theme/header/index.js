import { memo, useEffect, useRef, useState } from "react";
import "./style.scss";
import {
  AiOutlineDownCircle,
  AiOutlineFacebook,
  AiOutlineInstagram,
  AiOutlineLinkedin,
  AiOutlineMail,
  AiOutlineMenu,
  AiOutlinePhone,
  AiOutlineShoppingCart,
  AiOutlineUpCircle,
  AiOutlineUser,
} from "react-icons/ai";
import { Link } from "react-router-dom";
import { formatter } from "../../../../utils/formatter";
import { ROUTERS } from "../../../../utils/router";
import { BiUser } from "react-icons/bi";
const Header = () => {
  const [isShowHumberger, setShowHumberger] = useState();

  const [scrollDirection, setScrollDirection] = useState("up");
  const lastY = useRef(0);

  useEffect(() => {
    const handleScroll = () => {
      const currentY = window.scrollY;
      const diff = currentY - lastY.current;

      if (Math.abs(diff) > 100) {
        setScrollDirection(diff > 10 ? "down" : "up");
        lastY.current = currentY;
      }
    };

    window.addEventListener("scroll", handleScroll);
    return () => window.removeEventListener("scroll", handleScroll);
  }, []);

  const [menus, setMenus] = useState([
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
      <div
        className={`header ${
          scrollDirection === "up" ? "fixed-with-search" : "fixed-only"
        }`}
      >
        <div
          className={`hamberger__menu__wrapper ${
            isShowHumberger ? "show" : ""
          }`}
        >
          <div className="header__logo">
            <h1>Nina Shop</h1>
          </div>
          <div className="hamberger__menu__cart">
            <ul>
              <li>
                <Link to={""}>
                  <AiOutlineShoppingCart />
                  <span>1</span>
                </Link>
              </li>
            </ul>
            <div className="header__cart__price">
              Giỏ hàng: <span>{formatter(10000)}</span>
            </div>
          </div>
          <div className="hamberger__menu__widget">
            <div className="header__top__right__auth">
              <Link to={""}>
                {" "}
                <BiUser /> Đăng nhập
              </Link>
            </div>
          </div>
          <div className="humberger__menu_nav">
            <ul>
              {menus.map((menu, key) => (
                <li key={key} to={menu.path}>
                  {" "}
                  <Link
                    to={menu.path}
                    onClick={() => {
                      const newMenus = [...menus];
                      newMenus[key].isShowSubmenu =
                        !newMenus[key].isShowSubmenu;
                      setMenus(newMenus);
                    }}
                  >
                    {menu.name}
                    {menu.child &&
                      (menu.isShowSubmenu ? (
                        <AiOutlineDownCircle />
                      ) : (
                        <AiOutlineUpCircle />
                      ))}
                  </Link>
                  {menu.child && (
                    <ul
                      className={`header__menu__dropdown ${
                        menu.isShowSubmenu ? "show__submenu" : ""
                      }`}
                    >
                      {menu.child.map((menuChild, childKey) => (
                        <li key={`${key}-${childKey}`}>
                          <Link to={menuChild.path}>{menuChild.name}</Link>
                        </li>
                      ))}
                    </ul>
                  )}
                </li>
              ))}
            </ul>
          </div>

          <div className="humberger__menu_social">
            <Link to="">
              <AiOutlineFacebook />
            </Link>
            <Link to="">
              <AiOutlineInstagram />
            </Link>
            <Link to="">
              <AiOutlineLinkedin />
            </Link>
          </div>
        </div>
        {isShowHumberger && (
          <div
            className="menu__overlay"
            onClick={() => setShowHumberger(false)}
          />
        )}
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
        <div className="container header_menu">
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
              <div className="humberger_open">
                <AiOutlineMenu
                  onClick={() => {
                    setShowHumberger(!isShowHumberger);
                  }}
                />
              </div>
            </div>
          </div>
        </div>
        {scrollDirection === "up" && (
          <div className="container header_search">
            <div className="hero__search show">
              <div className="hero_search_form">
                <form>
                  <input type="text" placeholder="Enter keywords to search…" />
                  <button type="submit">Search</button>
                </form>
              </div>
              <div className="hero__search__phone">
                <div className="hero__search__phone__icon">
                  <AiOutlinePhone />
                </div>
                <div className="hero__search__phone__text">
                  <p>070.5355.331</p>
                  <span>Support Available 24/7</span>
                </div>
              </div>
            </div>
          </div>
        )}
      </div>
    </>
  );
};

export default memo(Header);
