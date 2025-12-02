import { memo, useState } from "react";
import "./style.scss";
import { Link } from "react-router-dom";
import {
  AiOutlineFacebook,
  AiOutlineInstagram,
  AiOutlineLinkedin,
} from "react-icons/ai";
const Footer = () => {
  return (
    <footer className="footer">
      <div className="container">
        <div className="row">
          <div className="col-xl-3 col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div className="footer__about">
              <h1 className="footer__about__logo">NINA SHOP</h1>
              <ul>
                <li>Address: Binh Thanh, Ho Chi Minh</li>
                <li>Phone: 070-5355-331</li>
                <li>Email: ni.tnh04@gmail.com</li>
              </ul>
            </div>
          </div>
          <div className="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div className="footer__widget">
              <h6>Store</h6>
              <ul>
                <li>
                  <Link to="">About Us</Link>
                </li>
                <li>
                  <Link to="">Products</Link>
                </li>
                <li>
                  <Link to="">Contact</Link>
                </li>
              </ul>
              <ul>
                <li>
                  <Link to="">Profile</Link>
                </li>
                <li>
                  <Link to="">Cart</Link>
                </li>
                <li>
                  <Link to="">Favourite</Link>
                </li>
              </ul>
            </div>
          </div>
          <div className="col-xl-3 col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div className="footer__widget">
              <h6>Discount</h6>
              <p>Subscribe for updates here</p>
              <form action="#">
                <div className="input-group">
                  <input type="text" placeholder="Enter your email" />
                  <button type="submit" className="button-submit">
                    Subscribe
                  </button>
                </div>
                <div className="footer__widget__social">
                  <div>
                    <AiOutlineFacebook />
                  </div>
                  <div>
                    <AiOutlineInstagram />
                  </div>
                  <div>
                    <AiOutlineLinkedin />
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default memo(Footer);
