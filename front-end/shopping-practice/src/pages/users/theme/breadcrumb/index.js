import { memo } from "react";
import { Link } from "react-router-dom";
import { ROUTERS } from "../../../../utils/router";
import "../breadcrumb/style.scss";
const Breadcrumb = (props) => {
  return (
    <>
      <div className="breadcrumb">
        <div className="breadcrumb__text">
          <div className="breadcrumb__option">
            <ul>
              <li className="link">
                <Link to={ROUTERS.USER.HOME}>Home</Link>
              </li>
              <li>{props.name}</li>
            </ul>
          </div>
        </div>
      </div>
    </>
  );
};

export default memo(Breadcrumb);
