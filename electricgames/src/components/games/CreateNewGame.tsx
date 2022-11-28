import { useContext, useEffect, useState, ChangeEvent } from "react";
import IGameContext from "../../interfaces/games/IGameContext";
import {GameContext} from "../../contexts/GameContext";
import IGame from "../../interfaces/games/IGame";
import GameList from "./GameList";
import Genre from "../../interfaces/games/GenreEnum";
import moment from "moment";
import "../../styles/games/Form.css"

const CreateNewGame = () => {

    const { postGameToService, getAllGamesFromService, uploadImageToService } = useContext(GameContext) as IGameContext;
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

    useEffect(() => {
        getAllGamesFromService();
    }, []);

    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.currentTarget;

        console.log(`handleChange - name: ${name}, value: ${value}, image: ${image}`);
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
    };

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

    const handleSubmit = () => {
        uploadImage();
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
    
    return (
        <section className="page-content-choice">
            <h3>Create new game</h3>
            <form className="page-form">
                <div className="form-group">
                    <label htmlFor="title">Title</label>
                    <input type="text" id="title" name="title" onChange={handleChange}/>

                    <label htmlFor="genre">Genre</label>
                    <select id="genre" name="genre" onChange={handleGenreSelect}>
                        {Object.keys(Genre).filter((key) => isNaN(Number(key))).map((key, value) => (
                            <option key={key} value={key}>{key}</option>
                        ))}
                    </select>
                </div>

                <div className="form-group">
                    <label htmlFor="platform">Platform</label>
                    <input type="text" id="platform" name="platform" onChange={handleChange}/>
                    <label htmlFor="developer">Developer</label>
                    <input type="text" id="developer" name="developer" onChange={handleChange}/>
                </div>

                <div className="form-group">
                    <label htmlFor="publisher">Publisher</label>
                    <input type="text" id="publisher" name="publisher" onChange={handleChange}/>
                    <label htmlFor="releaseDate">Release Date</label>
                    <input type="date" id="releaseDate" name="releaseDate" onChange={handleChange}/>
                </div>

                <div className="form-group">
                    <label htmlFor="price">Price</label>
                    <input type="number" id="price" name="price" onChange={handleChange}/>
                    <label htmlFor="rating">Rating</label>
                    <input type="number" id="rating" name="rating" onChange={handleChange}/>
                </div>

                <div className="form-group">
                    <label htmlFor="description">Description</label>
                    <input type="text" id="description" name="description" onChange={handleChange}/>
                    <label htmlFor="image">Image</label>
                    <input type="file" id="image" name="image" onChange={handleImageChange}/>
                </div>

                <button className="save-btn" type="button" onClick={handleSubmit}>Submit</button>
            </form>

            <section className="page-result">
                <GameList/>
            </section>
        </section>
    );
    // <label htmlFor="genre">Genre</label>
    //<input type="text" id="genre" name="genre" onChange={handleChange}/>
}

export default CreateNewGame


/**{Object.entries(Genre).filter(([key]) => key !== "10").map(([key, value]) => (
                        <option key={key} value={value}>{value}</option>
                    ))}
 * 
 * 
 * {Object.entries(Genre).map(([key, value]) => (
                        <option key={key} value={value}>{value}</option>
                    ))}
 * 
 * 
 * {Object.keys(Genre).map((key: number) => (
                        <option key={key} value={key}>{Genre[key].name}</option>
                    ))}
 * <option value={Genre.Action}>Action</option>
                    <option value={Genre.ActionAdventure}>Action Adventure</option>
                    <option value={Genre.Adventure}>Adventure</option>
                    <option value={Genre.Fighting}>Fighting</option>
                    <option value={Genre.Horror}>Horror</option>
                    <option value={Genre.MMO}>MMO</option>
                    <option value={Genre.Platformer}>Platformer</option>
                    <option value={Genre.Puzzle}>Puzzle</option>
                    <option value={Genre.Racing}>Racing</option>
                    <option value={Genre.RolePlaying}>Role Playing</option>
                    <option value={Genre.Sandbox}>Sand Box</option>
                    <option value={Genre.Shooter}>Shooter</option>
                    <option value={Genre.Simulation}>Simulation</option>
                    <option value={Genre.Sports}>Sports</option>
                    <option value={Genre.Strategy}>Strategy</option>
                    <option value={Genre.Unknown}>Unknown</option>
 */