import { useContext, useState, useRef, ChangeEvent, useEffect} from "react";
import IGameContext from "../../interfaces/games/IGameContext";
import { GameContext } from "../../contexts/GameContext";
import GameList from "./GameList";

const GetGamesByGenre = () => {

    const { getGamesByGenreFromService } = useContext(GameContext) as IGameContext;
    const [genre, setGenre] = useState<string>("Action");

    const inputOption = useRef<HTMLSelectElement>(null);

    /*const handleChange = (event: ChangeEvent<HTMLSelectElement>) => {
        const genre = event.currentTarget.value;
        setGenre((genre));
    }*/

    const handleChange = () => {
        const genre = inputOption.current?.value;
        setGenre((genre as string));
    }

    const convertGenreToNumber = (genre: string) => {
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
    };

    useEffect(() => { // du la på convertGenreToNumber, og har endret genre til number overalt
        getGamesByGenreFromService(convertGenreToNumber(genre));
    }, [convertGenreToNumber(genre), getGamesByGenreFromService]);

    return (
        <section className="page-content-choice">
            <h3>Find Games By Genre</h3>

            <div>
                <label htmlFor="genre">Select Genre: </label>
                <select id="genre" name="genre" value={genre} ref={inputOption} onChange={handleChange}>
                    <option value="Action">Action</option>
                    <option value="ActionAdventure">Action Adventure</option>
                    <option value="Adventure">Adventure</option>
                    <option value="Fighting">Fighting</option>
                    <option value="Horror">Horror</option>
                    <option value="MMO">MMO</option>
                    <option value="Platformer">Platformer</option>
                    <option value="Puzzle">Puzzle</option>
                    <option value="Racing">Racing</option>
                    <option value="RolePlaying">Role Playing</option>
                    <option value="SandBox">Sand Box</option>
                    <option value="Shooter">Shooter</option>
                    <option value="Simulation">Simulation</option>
                    <option value="Sports">Sports</option>
                    <option value="Strategy">Strategy</option>
                    <option value="Unknown">Unknown</option>
                </select>
            </div>

            <section className="page-result">
                <GameList />
            </section>
        </section>
    )
}

export default GetGamesByGenre