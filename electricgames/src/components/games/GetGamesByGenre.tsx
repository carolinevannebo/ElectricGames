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

    const handleGenreException = (genre: string) => {
        switch (genre) {
            case "Actionadventure":
                return "ActionAdventure";
            case "Roleplaying":
                return "RolePlaying";
            case "Mmo":
                return "MMO";
            default:
                return genre;
        }
    };

    useEffect(() => {
        getGamesByGenreFromService(genre);
    }, [genre, getGamesByGenreFromService]);

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