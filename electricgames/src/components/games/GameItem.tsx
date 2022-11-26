import IGame from "../../interfaces/games/IGame";
import '../../styles/shared/Item.css';

const GameItem = ({ 
    id, title, genre, platform, 
    developer, publisher, releaseDate, 
    price, rating, description, image  }: IGame ) => {
    
    return (
        <article>
            <div className="div-img">
                <img src={`https://localhost:7132/images/games/${image}`} alt={`${title}`}/> 
            </div>
            <div className="div-content">
                <h3>{title} <span>({id})</span></h3>
                <div>
                    <p>Genre:        <span className="color-seperator">{genre}</span></p>
                    <p>Platform:     <span className="color-seperator">{platform}</span></p>
                    <p>Developer:    <span className="color-seperator">{developer}</span></p>
                    <p>Publisher:    <span className="color-seperator">{publisher}</span></p>
                    <p>Release Date: <span className="color-seperator">{releaseDate}</span></p>
                    <p>Price:        <span className="color-seperator">{price}</span></p>
                    <p>Rating:       <span className="color-seperator">{rating}</span></p>
                    <p>Description:  <span className="color-seperator">{description}</span></p>
                </div>
            </div>
        </article>
    )
}

export default GameItem;