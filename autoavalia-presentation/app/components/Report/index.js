import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import { fetchReport } from './../../actions/index';
import { withRouter } from 'react-router-dom';
import Card from './../Card';


export default class Report extends Component {
	constructor(props) {
		super(props);

		this.state = {
			items: []
		};

		this.handleMyselfClick = this.handleMyselfClick.bind(this);
		this.onClickBackButton = this.onClickBackButton.bind(this);
	}

	componentWillMount() {
		fetchReport(this.props.match.params.questionary, (response) => {
			this.setState({ items: response.data })
		});
	}

	handleMyselfClick() {
		this.props.history.push('/painel');
	}

	onClickBackButton() {
		this.props.history.goBack();
	}

	render() {
		if (this.state.items.Clusters) {
			return (
				<div className="page page--report">
					<Header onClick={this.handleMyselfClick} onClickBackButton={this.onClickBackButton} />
					<main className="main">
						<section className="section section--car-data">
							<div className="container">
								<h2 className="section__title">Resultado da avaliação</h2>
							</div>
							<div className="car-data">
								<div className="car-data__image">
									<img src="https://image.webmotors.com.br/_fotos/anunciousados/gigante/2018/201803/20180302/honda-civic-2.0-16v-flexone-exl-4p-cvt-wmimagem13051521387.jpg?s=fill&w=657&h=492&q=75" />
								</div>
								<div className="container">
									<div className="car-data__content">
										<h3 className="car-data__title">HONDA CIVIC</h3>
										<span className="car-data__price">R$ 95.500</span>
										<span className="car-data__description">2.0 16V FLEXONE EXL 4P CVT 2016/2017</span>
										<span className="car-data__author"><strong>Feita por:</strong> lusiane • São Paulo </span>
									</div>
								</div>
							</div>
						</section>
						<section className="section section--car-report">
							<div className="container">
								<div className="cards">
									<Card title={"Situação do veículo"} description={"Dados de documentação e uso"} cluster={"situation"} details={false}>
										<div className="cards__item__table">
											<table>
												<tbody>
													<tr>
														<td>12.000 km</td>
														<td>35% abaixo do mercado</td>
													</tr>
													<tr>
														<td>R$ 25.000</td>
														<td>15% acima do mercado</td>
													</tr>
													<tr>
														<td>Custo sugerido de manutenção</td>
														<td>R$ 230</td>
													</tr>
													<tr>
														<td>IPVA e licenciamento</td>
														<td>R$ 1745,00</td>
													</tr>
													<tr>
														<td>Débitos</td>
														<td>R$ 560,00</td>
													</tr>
												</tbody>
											</table>
										</div>
									</Card>
									<Card title={"Histórico do veículo"} description={"Dados de documentação e uso"} cluster={"historic"}>
										<div className="cards__item__table">
											<table>
												<tbody>
													<tr>
														<td>Quantidade de donos</td>
														<td>2 donos</td>
													</tr>
													<tr>
														<td>Acidentes reportados</td>
														<td>Nenhum</td>
													</tr>
													<tr>
														<td>Histórico de roubo</td>
														<td>Nenhum</td>
													</tr>
													<tr>
														<td>Ofertas em leilão</td>
														<td>Nenhuma</td>
													</tr>
													<tr>
														<td>Recall</td>
														<td>Nenhum</td>
													</tr>
												</tbody>
											</table>
										</div>
									</Card>
									{this.state.items.Clusters.map((item) => {
										return (
											<Card title={item.Name} description={item.Description} cluster={item.Alias}>
												{item.Warnings > 0 ?
													<div className="cards__item__table">
														<table>
															<tbody>
																{item.Answers.map((answer) => {
																	return (
																		<tr>
																			<td>{answer.Name}</td>
																			<td>R$ {answer.Price}</td>
																		</tr>)
																})}
															</tbody>
														</table>
													</div>
													: null}
											</Card>
										)
									})}
								</div>
							</div>
						</section>
					</main>
					<Footer />
				</div>
			);
		} else {
			return null;
		}
	}
}