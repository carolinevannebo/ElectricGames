import { useContext, useEffect, useState, ChangeEvent } from "react";
import IGameContext from "../../interfaces/games/IGameContext";
import {GameContext} from "../../contexts/GameContext";
import IGame from "../../interfaces/games/IGame";
import GameList from "./GameList";

const CreateNewGame = () => {

    const { games, putGameToService } = useContext(GameContext) as IGameContext;
    //const [game, setGame] = useState<IGame>();
    const [title, setTitle] = useState<string>("");
    const [genre, setGenre] = useState<string>("");
    const [platform, setPlatform] = useState<string>("");
    const [developer, setDeveloper] = useState<string>("");
    const [publisher, setPublisher] = useState<string>("");
    const [releaseDate, setReleaseDate] = useState<string>("");
    const [price, setPrice] = useState<number>(0);
    const [description, setDescription] = useState<string>("");
    //const image

    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.currentTarget;

        switch (name) {
            case "title":
                setTitle(value);
                break;
            case "genre":
                setGenre(value);
                break;
            case "platform":
                setPlatform(value);
                break;
            case "developer":
                setDeveloper(value);
                break;
            case "publisher":
                setPublisher(value);
                break;
            case "releaseDate":
                setReleaseDate(value);
                break;
            case "price":
                setPrice(Number(value));
                break;
            case "description":
                setDescription(value);
                break;
        }
    };

    return (
        <section className="page-content-choice">
            <h3>Create new game</h3>
            <form className="page-form">
                <label htmlFor="title">Title</label>
                <input type="text" id="title" name="title" onChange={handleChange}/>
                <label htmlFor="genre">Genre</label>
                <input type="text" id="genre" name="genre" onChange={handleChange}/>
                <label htmlFor="platform">Platform</label>
                <input type="text" id="platform" name="platform" onChange={handleChange}/>
                <label htmlFor="developer">Developer</label>
                <input type="text" id="developer" name="developer" onChange={handleChange}/>
                <label htmlFor="publisher">Publisher</label>
                <input type="text" id="publisher" name="publisher" onChange={handleChange}/>
                <label htmlFor="releaseDate">Release Date</label>
                <input type="datetime-local" id="releaseDate" name="releaseDate" onChange={handleChange}/>
                <label htmlFor="price">Price</label>
                <input type="text" id="price" name="price" onChange={handleChange}/>
                <label htmlFor="description">Description</label>
                <input type="text" id="description" name="description" onChange={handleChange}/>
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