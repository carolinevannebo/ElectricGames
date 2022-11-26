import {Link} from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap-grid.min.css';
import '../../styles/shared/SharedHeader.css';

const MainPageHeader = () => {
    return (
        <header>
            <div className='img-container'>
                
                    <Link to="/">
                    <img src={require('../../assets/images/ElectricGamesLogo.png')} alt='logo' className='img-logo'/>
                    </Link>
                
            </div>
            <nav className='container-fluid'>
                <ul className='row'>
                    <li className="col-lg col-md col-sm"></li>

                    <li className='col-lg col-md col-sm'>
                        <Link to="/games">Games</Link>
                    </li>

                    <li className='col-lg col-md col-sm'>
                        <Link to="/characters">Characters</Link>
                    </li>

                    <li className='col-lg col-md col-sm'>
                        <Link to="/locations">Locations</Link>
                    </li>

                    <li className="col-lg col-md col-sm"></li>
                </ul>
            </nav>
        </header>
    )
}

export default MainPageHeader;