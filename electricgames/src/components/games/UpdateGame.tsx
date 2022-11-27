import { useContext, useEffect, useState, ChangeEvent } from "react";
import IGameContext from "../../interfaces/games/IGameContext";
import {GameContext} from "../../contexts/GameContext";
import IGame from "../../interfaces/games/IGame";
import GameList from "./GameList";
import Genre from "../../interfaces/games/GenreEnum";

const CreateNewGame = () => {

    const { uploadImageToService, getAllGamesFromService, getGameByIdFromService } = useContext(GameContext) as IGameContext;
    const [id, setId] = useState<number>(1001);
    const [title, setTitle] = useState<string>("");
    const [genre, setGenre] = useState<Genre>(Genre.Unknown);
    const [platform, setPlatform] = useState<string>("");
    const [developer, setDeveloper] = useState<string>("");
    const [publisher, setPublisher] = useState<string>("");
    const [releaseDate, setReleaseDate] = useState<Date>({} as Date);
    const [price, setPrice] = useState<number>(0);
    const [rating, setRating] = useState<number>(0);
    const [description, setDescription] = useState<string>("");
    const [image, setImage] = useState<File | null>(null);
}

export default CreateNewGame;