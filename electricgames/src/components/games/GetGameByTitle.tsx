import { useContext, useState, ChangeEvent, useEffect} from "react";
import IGameContext from "../../interfaces/games/IGameContext";
import { GameContext } from "../../contexts/GameContext";
import GameList from "./GameList";

const GetGameByTitle = () => {

    const { getGameByTitleFromService } = useContext(GameContext) as IGameContext;
    const [title, setTitle] = useState<string>("Batman: Arkham City");

    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const title = event.currentTarget.value;
        setTitle(toTitleCase(title));
    }

    //Bug: If you type in a title that doesn't exist, it will return the last title that did exist.
    //Bug: Bioshock Infinite returns an error. It's not in the database. Supposed to be BioShock Infinite. Bra jobba Caro:))
    const toTitleCase = (str: string) => {
        return str.replace(
            /\w\S*/g,
            (txt) => {
                return txt.charAt(0).toUpperCase() + txt.substring(1).toLowerCase();
            }
        );
    }

    useEffect(() => {
        getGameByTitleFromService(title);
    }, [title, getGameByTitleFromService]);

    return (
        <section className="page-content-choice">
            <h3>Find Game By Title</h3>

            <div>
                <label htmlFor="title">Enter Game Title: </label>
                <input type="text" id="title" name="title" value={title} onChange={handleChange} />
            </div>

            <section className="page-result">
                <GameList />
            </section>
        </section>
    )

}

export default GetGameByTitle;