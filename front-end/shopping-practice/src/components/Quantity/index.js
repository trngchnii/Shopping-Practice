import { memo, useState } from "react";
import "./style.scss";
import { AiOutlineHeart } from "react-icons/ai";
const Quantity = ({ hasAddToCart = true, onAddToCart }) => {
  const [value, setValue] = useState(1);
  const handleChange = (e) => {
    setValue(Number(e.target.value));
  };
  return (
    <>
      <div className="quantity-container">
        <div className="quantity">
          <span
            className="quantity-btn"
            onClick={() => setValue((prev) => Math.max(1, prev - 1))}
          >
            -
          </span>
          <input type="number" value={value} onChange={handleChange} />
          <span
            className="quantity-btn"
            onClick={() => setValue((prev) => prev + 1)}
          >
            +
          </span>
        </div>
        {hasAddToCart && (
          <div className="product_actions">
            <button className="btn_add_to_bag">ADD TO BAG</button>
            <button className="btn_favorite">
              <AiOutlineHeart />
              Favorite
            </button>
          </div>
        )}
      </div>
    </>
  );
};

export default memo(Quantity);
