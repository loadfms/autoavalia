import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import Card from '../Card';
import {fetchCluster} from './../../actions/index';

export default class Panel extends Component {
	constructor(props) {
		super(props);
		
		this.state = {
			items: []
		}
	}
	
	
	componentWillMount() {
		let _this = this;
		fetchCluster(1,1, (data) => {
			_this.setState({items: data });
		});
	}
	
	render() {
		return (
			<div className="page page--panel">
				<Header />
				<main className="main">
					<section className="section section--total-progress">
						<Card title={"Avaliação do veículo"} type={"internal"} cluster={"total-progress"} />
					</section>
					<section className="section section--cards">
						<div className="container">
							<div className="cards">
								<Card title={"Histórico do veículo"} description={"Dados de documentação e uso"} cluster={"historic"} filledSteps={2} totalSteps={7} />
								<Card title={"Interior"} description={"Dados de documentação e uso"} cluster={"inside"} filledSteps={2} totalSteps={8} />
								<Card title={"Funilaria"} description={"Dados de documentação e uso"} cluster={"funnel"} filledSteps={2} totalSteps={9} />
								<Card title={"Pneus"} description={"Dados de documentação e uso"} cluster={"tires"} filledSteps={2} totalSteps={14} />
								<Card title={"Elétrica"} description={"Dados de documentação e uso"} cluster={"eletric"} filledSteps={2} totalSteps={5} />
								<Card title={"Mecânica"} description={"Dados de documentação e uso"} cluster={"mechanic"} filledSteps={2} totalSteps={6} />
							</div>
						</div>
					</section>
					<button className="button button--success">Continuar</button>
				</main>
				<Footer />
			</div>
		);
	}
}