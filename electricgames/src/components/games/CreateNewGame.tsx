import { useContext, useEffect, useState, ChangeEvent } from "react";
import IGameContext from "../../interfaces/games/IGameContext";
import {GameContext} from "../../contexts/GameContext";
import IGame from "../../interfaces/games/IGame";
import GameList from "./GameList";

const CreateNewGame = () => {

    const { postGameToService, getAllGamesFromService, uploadImageToService } = useContext(GameContext) as IGameContext;
    //const [game, setGame] = useState<IGame>();
    const [title, setTitle] = useState<string>("");
    const [genre, setGenre] = useState<string>("");
    const [platform, setPlatform] = useState<string>("");
    const [developer, setDeveloper] = useState<string>("");
    const [publisher, setPublisher] = useState<string>("");
    const [releaseDate, setReleaseDate] = useState<string>("");
    const [price, setPrice] = useState<number>(0);
    const [rating, setRating] = useState<number>(0);
    const [description, setDescription] = useState<string>("");
    const [image, setImage] = useState<File | null>(null);
    //const image

    useEffect(() => {
        getAllGamesFromService();
    }, []);

    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.currentTarget;
        const image = event.target.files![0];

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
            case "rating":
                setRating(Number(value));
                break;
            case "description":
                setDescription(value);
                break;
            case "image":
                setImage(image);
                break;
        }
        //const image = event.target.files![0];
        //setImage(image);
    };

    /*const convertGenreToNumber = (genre: string) => {
        switch (genre) {
            case "Action":
                return 0;
            case "ActionAdventure":
                return 1;
            case "Adventure":
                return 2;
            case "Fighting":
                return 3;
            case "Horror":
                return 4;
            case "MMO":
                return 5;
            case "Platformer":
                return 6;
            case "Puzzle":
                return 7;
            case "Racing":
                return 8;
            case "RolePlaying":
                return 9;
            case "SandBox":
                return 10;
            case "Shooter":
                return 11;
            case "Simulation":
                return 12;
            case "Sports":
                return 13;
            case "Strategy":
                return 14;
            default:
                return 15;
        }
    };*/

    const uploadImage = () => {
        image != null ? uploadImageToService(image) : console.log("No image selected");
    }

    const handleSubmit = () => {
        uploadImage();
        //event.preventDefault();
        const game: IGame = {
            title: title,
            genre: genre,
            platform: platform,
            developer: developer,
            publisher: publisher,
            releaseDate: releaseDate,
            price: price,
            rating: rating,
            description: description,
            image: image!.name
        };

        postGameToService(game);
    }
                    // fjernet  onSubmit={handleSubmit} fra form
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
                <input type="date" id="releaseDate" name="releaseDate" onChange={handleChange}/>
                <label htmlFor="price">Price</label>
                <input type="number" id="price" name="price" onChange={handleChange}/>
                <label htmlFor="rating">Rating</label>
                <input type="number" id="rating" name="rating" onChange={handleChange}/>
                <label htmlFor="description">Description</label>
                <input type="text" id="description" name="description" onChange={handleChange}/>
                <label htmlFor="image">Image</label>
                <input type="file" id="image" name="image" onChange={handleChange}/>
                <button type="button" onClick={handleSubmit}>Submit</button>
            </form>

            <section className="page-result">
                <GameList/>
            </section>
        </section>
    );
}

export default CreateNewGame
