import IGame from "../../interfaces/games/IGame";
import IGameContext from "../../interfaces/games/IGameContext";
import { GameContext } from "../../contexts/GameContext";
import { useState, useEffect, useContext } from "react";

const GameItem = ({ id, title, genre, platform, developer, publisher, releaseDate, price, rating, description, image  }: IGame ) => {
    
    /*const { games,  } = useContext(GameContext) as IGameContext;
    const [imagePath, setImagePath] = useState<string>("");

    useEffect(() => {
        getImagePathFromService();
    }, []);*/
    
    return (
        <article>
            <div>
                <img src={`https://localhost:7132/images/games/${image}`} alt={`${title}`}/> 
            </div>
            <div>
                <h3>{title} ({id})</h3>
                <div>
                    <p>Genre: {genre}</p>
                    <p>Platform: {platform}</p>
                    <p>Developer: {developer}</p>
                    <p>Publisher: {publisher}</p>
                    <p>Release Date: {releaseDate}</p>
                    <p>Price: {price}</p>
                    <p>Rating: {rating}</p>
                    <p>Description: {description}</p>
                </div>
            </div>
        </article>
    )
}

export default GameItem;