import { useContext, useEffect, useState, ChangeEvent } from "react";
import IGameContext from "../../interfaces/games/IGameContext";
import {GameContext} from "../../contexts/GameContext";
import IGame from "../../interfaces/games/IGame";
import GameList from "./GameList";
import Genre from "../../interfaces/games/GenreEnum";
import moment from "moment";
import { useNavigate } from "react-router-dom";
import "../../styles/games/Form.css";

const UpdateGame= () => {

    const { uploadImageToService, putGameToService, getGameByIdFromService } = useContext(GameContext) as IGameContext;
    const [id, setId] = useState<number>(1001);
    const [title, setTitle] = useState<string>("");
    const [genre, setGenre] = useState<Genre>(Genre.Unknown);
    const [platform, setPlatform] = useState<string[]>([]);
    const [developer, setDeveloper] = useState<string>("");
    const [publisher, setPublisher] = useState<string>("");
    const [releaseDate, setReleaseDate] = useState(moment().format("YYYY-MM-DD"));
    const [price, setPrice] = useState<number>(0);
    const [rating, setRating] = useState<number>(0);
    const [description, setDescription] = useState<string>("");
    const [image, setImage] = useState<File | null>(null);

    const navigate = useNavigate();

    useEffect(() => {
        getGameByIdFromService(id);
    }, [getGameByIdFromService, id]);

    const handleId = (event: ChangeEvent<HTMLInputElement>) => {
        const id = event.currentTarget.value;
        setId(parseInt(id));
    }

    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const {name, value} = event.currentTarget;

        switch (name) {
            case "title":
                setTitle(value);
                break;
            case "platform":
                setPlatform([value]);
                break;
            case "developer":
                setDeveloper(value);
                break;
            case "publisher":
                setPublisher(value);
                break;
            case "releaseDate":
                setReleaseDate(moment(new Date(value)).format("YYYY-MM-DD"));
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
        }
    }

    const handleGenreSelect = (event: ChangeEvent<HTMLSelectElement>) => {
        const { value } = event.currentTarget;
        setGenre(value as unknown as Genre);
    }

    const handleImageChange = (event: ChangeEvent<HTMLInputElement>) => {
        const image = event.target.files![0];
        setImage(image);
    }

    const uploadImage = () => {
        image != null ? uploadImageToService(image) : console.log("No image selected");
    }

    const updateGame = () => {
        uploadImage();
        const game: IGame = {
            //id: id,
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
        }

        putGameToService(game, id);
        navigate("/games/get-all-games"); // /games/update-game?id=id   //get-all-games?
    }

    return (
        <section className="page-content-choice">
            <h3>Update Game</h3>


            <form className="page-form">
                <div className="form-group">
                    <label htmlFor="id">Enter Game ID: </label>
                    <input type="number" id="id" name="id" value={id} onChange={handleId}/>
                    <label htmlFor="title">Title: </label>
                    <input type="text" id="title" name="title" value={title} onChange={handleChange}/>
                </div>

                <div className="form-group">
                    <label htmlFor="genre">Genre: </label>
                    <select id="genre" name="genre" onChange={handleGenreSelect}>
                        {Object.keys(Genre).filter((key) => isNaN(Number(key))).map((key, value) => (
                            <option key={key} value={key}>{key}</option>
                        ))}
                    </select>
                    <label htmlFor="platform">Platform</label>
                    <input type="text" id="platform" name="platform" onChange={handleChange}/>
                </div>

                <div className="form-group">
                    <label htmlFor="developer">Developer</label>
                    <input type="text" id="developer" name="developer" onChange={handleChange}/>
                    <label htmlFor="publisher">Publisher</label>
                    <input type="text" id="publisher" name="publisher" onChange={handleChange}/>
                </div>

                <div className="form-group">
                    <label htmlFor="releaseDate">Release Date</label>
                    <input type="date" id="releaseDate" name="releaseDate" onChange={handleChange}/>
                    <label htmlFor="price">Price</label>
                    <input type="number" id="price" name="price" onChange={handleChange}/>
                </div>

                <div className="form-group">
                    <label htmlFor="rating">Rating</label>
                    <input type="number" id="rating" name="rating" onChange={handleChange}/>
                    <label htmlFor="description">Description</label>
                    <input type="text" id="description" name="description" onChange={handleChange}/>
                </div>

                <div className="form-group">
                    <label htmlFor="image">Image</label>
                    <input type="file" id="image" name="image" onChange={handleImageChange}/>
                    <label></label>
                    <button type="button" onClick={updateGame}>Submit</button>
                </div>

            </form>

            <GameList />
        </section>
    );
}

export default UpdateGame;