import { useContext, useEffect, useState, ChangeEvent } from "react";
import IGameContext from "../../interfaces/games/IGameContext";
import {GameContext} from "../../contexts/GameContext";
import IGame from "../../interfaces/games/IGame";
import GameList from "./GameList";

const CreateNewGame = () => {

    const { games, putGameToService } = useContext(GameContext) as IGameContext;
    const [game, setGame] = useState<IGame>();

    return (
        <section className="page-content-choice">
            <h3>Create new game</h3>
            <form className="page-form">
                <label htmlFor="title">Title</label>
                <input type="text" id="title" name="title"/>
                <label htmlFor="genre">Genre</label>
                <input type="text" id="genre" name="genre"/>
                <label htmlFor="platform">Platform</label>
                <input type="text" id="platform" name="platform"/>
                <label htmlFor="developer">Developer</label>
                <input type="text" id="developer" name="developer"/>
                <label htmlFor="publisher">Publisher</label>
                <input type="text" id="publisher" name="publisher"/>
                <label htmlFor="releaseDate">Release Date</label>
                <input type="text" id="releaseDate" name="releaseDate"/>
                <label htmlFor="price">Price</label>
                <input type="text" id="price" name="price"/>
                <label htmlFor="description">Description</label>
                <input type="text" id="description" name="description"/>
                <label htmlFor="image">Image</label>
                <input type="text" id="image" name="image"/>
                <button type="submit">Submit</button>
            </form>

            <section className="page-result">
                <GameList/>
            </section>
        </section>
    );
}

export default CreateNewGame