﻿' ################################################################################
' #                             EMBER MEDIA MANAGER                              #
' ################################################################################
' ################################################################################
' # This file is part of Ember Media Manager.                                    #
' #                                                                              #
' # Ember Media Manager is free software: you can redistribute it and/or modify  #
' # it under the terms of the GNU General Public License as published by         #
' # the Free Software Foundation, either version 3 of the License, or            #
' # (at your option) any later version.                                          #
' #                                                                              #
' # Ember Media Manager is distributed in the hope that it will be useful,       #
' # but WITHOUT ANY WARRANTY; without even the implied warranty of               #
' # MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
' # GNU General Public License for more details.                                 #
' #                                                                              #
' # You should have received a copy of the GNU General Public License            #
' # along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
' ################################################################################
' #
' # Dialog size: 564; 462
' # Enlarge it to see all the panels.

Imports System.IO
Imports EmberAPI

Public Class dlgWizard

    Private tLang As String
    Private tmppath As String = String.Empty

#Region "Methods"

	Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
		Select Case True
            Case Me.pnlMovieSource.Visible
                Me.btnBack.Enabled = False
                Me.pnlMovieSource.Visible = False
                Me.pnlWelcome.Visible = True
            Case Me.pnlMovieSettings.Visible
                Me.pnlMovieSettings.Visible = False
                Me.pnlMovieSource.Visible = True
            Case Me.pnlTVShowSource.Visible
                Me.pnlTVShowSource.Visible = False
                Me.pnlMovieSettings.Visible = True
            Case Me.pnlTVShowSettings.Visible
                Me.pnlTVShowSettings.Visible = False
                Me.pnlTVShowSource.Visible = True
            Case Me.pnlDone.Visible
                Me.pnlDone.Visible = False
                Me.pnlTVShowSettings.Visible = True
                Me.btnNext.Enabled = True
                Me.OK_Button.Enabled = False
        End Select
    End Sub

    Private Sub btnMovieAddFolders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMovieAddFolder.Click
        Using dSource As New dlgMovieSource()
            If dSource.ShowDialog(tmppath) = Windows.Forms.DialogResult.OK Then
                RefreshSources()
            End If
        End Using
    End Sub

    Private Sub btnMovieRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMovieRem.Click
        Me.RemoveSource()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Select Case True
            Case Me.pnlWelcome.Visible
                Me.btnBack.Enabled = True
                Me.pnlWelcome.Visible = False
                Me.pnlMovieSource.Visible = True
            Case Me.pnlMovieSource.Visible
                Me.pnlMovieSource.Visible = False
                Me.pnlMovieSettings.Visible = True
            Case Me.pnlMovieSettings.Visible
                Me.pnlMovieSettings.Visible = False
                Me.pnlTVShowSource.Visible = True
            Case Me.pnlTVShowSource.Visible
                Me.pnlTVShowSource.Visible = False
                Me.pnlTVShowSettings.Visible = True
            Case Me.pnlTVShowSettings.Visible
                Me.pnlTVShowSettings.Visible = False
                Me.pnlDone.Visible = True
                Me.btnNext.Enabled = False
                Me.OK_Button.Enabled = True
        End Select
    End Sub

    Private Sub btnTVAddSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTVAddSource.Click
        Using dSource As New dlgTVSource
            If dSource.ShowDialog(tmppath) = Windows.Forms.DialogResult.OK Then
                RefreshTVSources()
            End If
        End Using
    End Sub

    Private Sub btnTVRemoveSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTVRemoveSource.Click
        Me.RemoveTVSource()
    End Sub

    Private Sub chkUseFrodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseFrodo.CheckedChanged

        Me.chkActorThumbsFrodo.Enabled = Me.chkUseFrodo.Checked
        Me.chkBannerFrodo.Enabled = Me.chkUseFrodo.Checked
        Me.chkClearArtFrodo.Enabled = Me.chkUseFrodo.Checked
        Me.chkClearLogoFrodo.Enabled = Me.chkUseFrodo.Checked
        Me.chkExtrafanartsFrodo.Enabled = Me.chkUseFrodo.Checked
        Me.chkExtrathumbsFrodo.Enabled = Me.chkUseFrodo.Checked
        Me.chkDiscArtFrodo.Enabled = Me.chkUseFrodo.Checked
        Me.chkFanartFrodo.Enabled = Me.chkUseFrodo.Checked
        Me.chkLandscapeFrodo.Enabled = Me.chkUseFrodo.Checked
        Me.chkNFOFrodo.Enabled = Me.chkUseFrodo.Checked
        Me.chkPosterFrodo.Enabled = Me.chkUseFrodo.Checked
        Me.chkTrailerFrodo.Enabled = Me.chkUseFrodo.Checked

        If Not Me.chkUseFrodo.Checked Then
            Me.chkActorThumbsFrodo.Checked = False
            Me.chkBannerFrodo.Checked = False
            Me.chkClearArtFrodo.Checked = False
            Me.chkClearLogoFrodo.Checked = False
            Me.chkDiscArtFrodo.Checked = False
            Me.chkExtrafanartsFrodo.Checked = False
            Me.chkExtrathumbsFrodo.Checked = False
            Me.chkFanartFrodo.Checked = False
            Me.chkLandscapeFrodo.Checked = False
            Me.chkNFOFrodo.Checked = False
            Me.chkPosterFrodo.Checked = False
            Me.chkTrailerFrodo.Checked = False
        Else
            Me.chkActorThumbsFrodo.Checked = True
            Me.chkBannerFrodo.Checked = True
            Me.chkClearArtFrodo.Checked = True
            Me.chkClearLogoFrodo.Checked = True
            Me.chkDiscArtFrodo.Checked = True
            Me.chkExtrafanartsFrodo.Checked = True
            Me.chkExtrathumbsFrodo.Checked = True
            Me.chkFanartFrodo.Checked = True
            Me.chkLandscapeFrodo.Checked = True
            Me.chkNFOFrodo.Checked = True
            Me.chkPosterFrodo.Checked = True
            Me.chkTrailerFrodo.Checked = True
        End If
    End Sub

    Private Sub chkUseEden_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseEden.CheckedChanged

        Me.chkActorThumbsEden.Enabled = Me.chkUseEden.Checked
        'Me.chkBannerEden.Enabled = Me.chkUseEden.Checked
        'Me.chkClearArtEden.Enabled = Me.chkUseEden.Checked
        'Me.chkClearLogoEden.Enabled = Me.chkUseEden.Checked
        Me.chkExtrafanartsEden.Enabled = Me.chkUseEden.Checked
        Me.chkExtrathumbsEden.Enabled = Me.chkUseEden.Checked
        'Me.chkDiscArtEden.Enabled = Me.chkUseEden.Checked
        Me.chkFanartEden.Enabled = Me.chkUseEden.Checked
        'Me.chkLandscapeEden.Enabled = Me.chkUseEden.Checked
        Me.chkNFOEden.Enabled = Me.chkUseEden.Checked
        Me.chkPosterEden.Enabled = Me.chkUseEden.Checked
        Me.chkTrailerEden.Enabled = Me.chkUseEden.Checked

        If Not Me.chkUseEden.Checked Then
            Me.chkActorThumbsEden.Checked = False
            'Me.chkBannerEden.Checked = False
            'Me.chkClearArtEden.Checked = False
            'Me.chkClearLogoEden.Checked = False
            'Me.chkDiscArtEden.Checked = False
            Me.chkExtrafanartsEden.Checked = False
            Me.chkExtrathumbsEden.Checked = False
            Me.chkFanartEden.Checked = False
            'Me.chkLandscapeEden.Checked = False
            Me.chkNFOEden.Checked = False
            Me.chkPosterEden.Checked = False
            Me.chkTrailerEden.Checked = False
        Else
            Me.chkActorThumbsEden.Checked = True
            'Me.chkBannerEden.Checked = True
            'Me.chkClearArtEden.Checked = True
            'Me.chkClearLogoEden.Checked = True
            'Me.chkDiscArtEden.Checked = True
            Me.chkExtrafanartsEden.Checked = True
            Me.chkExtrathumbsEden.Checked = True
            Me.chkFanartEden.Checked = True
            'Me.chkLandscapeEden.Checked = True
            Me.chkNFOEden.Checked = True
            Me.chkPosterEden.Checked = True
            Me.chkTrailerEden.Checked = True
        End If
    End Sub

    Private Sub chkUseYAMJCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseYAMJ.CheckedChanged

        'Me.chkActorThumbsYAMJ.Enabled = Me.chkUseYAMJ.Checked
        Me.chkBannerYAMJ.Enabled = Me.chkUseYAMJ.Checked
        'Me.chkClearArtYAMJ.Enabled = Me.chkUseYAMJ.Checked
        'Me.chkClearLogoYAMJ.Enabled = Me.chkUseYAMJ.Checked
        'Me.chkExtrafanartYAMJ.Enabled = Me.chkUseYAMJ.Checked
        'Me.chkExtrathumbsYAMJ.Enabled = Me.chkUseYAMJ.Checked
        'Me.chkDiscArtYAMJ.Enabled = Me.chkUseYAMJ.Checked
        Me.chkFanartYAMJ.Enabled = Me.chkUseYAMJ.Checked
        'Me.chkLandscapeYAMJ.Enabled = Me.chkUseYAMJ.Checked
        Me.chkNFOYAMJ.Enabled = Me.chkUseYAMJ.Checked
        Me.chkPosterYAMJ.Enabled = Me.chkUseYAMJ.Checked
        Me.chkTrailerYAMJ.Enabled = Me.chkUseYAMJ.Checked

        If Not Me.chkUseYAMJ.Checked Then
            ' Me.chkActorThumbsYAMJ.Checked = False
            Me.chkBannerYAMJ.Checked = False
            'Me.chkClearArtYAMJ.Checked = False
            'Me.chkClearLogoYAMJ.Checked = False
            'Me.chkDiscArtYAMJ.Checked = False
            'Me.chkExtrafanartYAMJ.Checked = False
            'Me.chkExtrathumbsYAMJ.Checked = False
            Me.chkFanartYAMJ.Checked = False
            'Me.chkLandscapeYAMJ.Checked = False
            Me.chkNFOYAMJ.Checked = False
            Me.chkPosterYAMJ.Checked = False
            Me.chkTrailerYAMJ.Checked = False
        Else
            'Me.chkActorThumbsYAMJ.Checked = True
            Me.chkBannerYAMJ.Checked = True
            'Me.chkClearArtYAMJ.Checked = True
            'Me.chkClearLogoYAMJ.Checked = True
            'Me.chkDiscArtYAMJ.Checked = True
            'Me.chkExtrafanartYAMJ.Checked = True
            'Me.chkExtrathumbsYAMJ.Checked = True
            Me.chkFanartYAMJ.Checked = True
            'Me.chkLandscapeYAMJ.Checked = True
            Me.chkNFOYAMJ.Checked = True
            Me.chkPosterYAMJ.Checked = True
            Me.chkTrailerYAMJ.Checked = True
        End If
    End Sub

    Private Sub chkUseNMJCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseNMJ.CheckedChanged

        'Me.chkActorThumbsNMJ.Enabled = Me.chkUseNMJ.Checked
        Me.chkBannerNMJ.Enabled = Me.chkUseNMJ.Checked
        'Me.chkClearArtNMJ.Enabled = Me.chkUseNMJ.Checked
        'Me.chkClearLogoNMJ.Enabled = Me.chkUseNMJ.Checked
        'Me.chkExtrafanartNMJ.Enabled = Me.chkUseNMJ.Checked
        'Me.chkExtrathumbsNMJ.Enabled = Me.chkUseNMJ.Checked
        'Me.chkDiscArtNMJ.Enabled = Me.chkUseNMJ.Checked
        Me.chkFanartNMJ.Enabled = Me.chkUseNMJ.Checked
        'Me.chkLandscapeNMJ.Enabled = Me.chkUseNMJ.Checked
        Me.chkNFONMJ.Enabled = Me.chkUseNMJ.Checked
        Me.chkPosterNMJ.Enabled = Me.chkUseNMJ.Checked
        Me.chkTrailerNMJ.Enabled = Me.chkUseNMJ.Checked

        If Not Me.chkUseNMJ.Checked Then
            ' Me.chkActorThumbsNMJ.Checked = False
            Me.chkBannerNMJ.Checked = False
            'Me.chkClearArtNMJ.Checked = False
            'Me.chkClearLogoNMJ.Checked = False
            'Me.chkDiscArtNMJ.Checked = False
            'Me.chkExtrafanartNMJ.Checked = False
            'Me.chkExtrathumbsNMJ.Checked = False
            Me.chkFanartNMJ.Checked = False
            'Me.chkLandscapeNMJ.Checked = False
            Me.chkNFONMJ.Checked = False
            Me.chkPosterNMJ.Checked = False
            Me.chkTrailerNMJ.Checked = False
        Else
            'Me.chkActorThumbsNMJ.Checked = True
            Me.chkBannerNMJ.Checked = True
            'Me.chkClearArtNMJ.Checked = True
            'Me.chkClearLogoNMJ.Checked = True
            'Me.chkDiscArtNMJ.Checked = True
            'Me.chkExtrafanartNMJ.Checked = True
            'Me.chkExtrathumbsNMJ.Checked = True
            Me.chkFanartNMJ.Checked = True
            'Me.chkLandscapeNMJ.Checked = True
            Me.chkNFONMJ.Checked = True
            Me.chkPosterNMJ.Checked = True
            Me.chkTrailerNMJ.Checked = True
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cbIntLang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIntLang.SelectedIndexChanged
        If Not String.IsNullOrEmpty(Me.cbIntLang.SelectedItem.ToString) AndAlso Not (Me.cbIntLang.SelectedItem.ToString = tLang) Then
            Master.eLang.LoadAllLanguage(Me.cbIntLang.SelectedItem.ToString, True)
            tLang = Me.cbIntLang.SelectedItem.ToString
            Me.SetUp()
        End If
    End Sub

    Private Sub dlgWizard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetUp()
        Me.LoadIntLangs()
        Me.FillSettings()
    End Sub

    Private Sub dlgWizard_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.Activate()
    End Sub

    Private Sub FillSettings()
        Me.RefreshSources()
        Me.RefreshTVSources()

        Me.chkUseFrodo.Checked = Master.eSettings.UseFrodo
        Me.chkActorThumbsFrodo.Checked = Master.eSettings.ActorThumbsFrodo
        Me.chkBannerFrodo.Checked = Master.eSettings.BannerFrodo
        Me.chkClearArtFrodo.Checked = Master.eSettings.ClearArtFrodo
        Me.chkClearLogoFrodo.Checked = Master.eSettings.ClearLogoFrodo
        Me.chkDiscArtFrodo.Checked = Master.eSettings.DiscArtFrodo
        Me.chkExtrafanartsFrodo.Checked = Master.eSettings.ExtrafanartsFrodo
        Me.chkExtrathumbsFrodo.Checked = Master.eSettings.ExtrathumbsFrodo
        Me.chkFanartFrodo.Checked = Master.eSettings.FanartFrodo
        Me.chkLandscapeFrodo.Checked = Master.eSettings.LandscapeFrodo
        Me.chkNFOFrodo.Checked = Master.eSettings.NFOFrodo
        Me.chkPosterFrodo.Checked = Master.eSettings.PosterFrodo
        Me.chkTrailerFrodo.Checked = Master.eSettings.TrailerFrodo

        Me.chkUseEden.Checked = Master.eSettings.UseEden
        Me.chkActorThumbsEden.Checked = Master.eSettings.ActorThumbsEden
        Me.chkExtrafanartsEden.Checked = Master.eSettings.ExtrafanartsEden
        Me.chkExtrathumbsEden.Checked = Master.eSettings.ExtrathumbsEden
        Me.chkFanartEden.Checked = Master.eSettings.FanartEden
        Me.chkNFOEden.Checked = Master.eSettings.NFOEden
        Me.chkPosterEden.Checked = Master.eSettings.PosterEden
        Me.chkTrailerEden.Checked = Master.eSettings.TrailerEden

        Me.chkXBMCTrailerFormat.Checked = Master.eSettings.XBMCTrailerFormat

        Me.chkUseYAMJ.Checked = Master.eSettings.UseYAMJ
        Me.chkBannerYAMJ.Checked = Master.eSettings.BannerYAMJ
        Me.chkFanartYAMJ.Checked = Master.eSettings.FanartYAMJ
        Me.chkNFONMJ.Checked = Master.eSettings.NFOYAMJ
        Me.chkPosterYAMJ.Checked = Master.eSettings.PosterYAMJ
        Me.chkTrailerYAMJ.Checked = Master.eSettings.TrailerYAMJ

        Me.chkUseNMJ.Checked = Master.eSettings.UseNMJ
        Me.chkBannerNMJ.Checked = Master.eSettings.BannerNMJ
        Me.chkFanartNMJ.Checked = Master.eSettings.FanartNMJ
        Me.chkNFONMJ.Checked = Master.eSettings.NFONMJ
        Me.chkPosterNMJ.Checked = Master.eSettings.PosterNMJ
        Me.chkTrailerNMJ.Checked = Master.eSettings.TrailerNMJ

        Me.chkSeasonAllPosterJPG.Checked = Master.eSettings.SeasonAllPosterJPG
        Me.chkSeasonXXDashPosterJPG.Checked = Master.eSettings.SeasonXXDashPosterJPG
        Me.chkMovieNameDashPosterJPG.Checked = Master.eSettings.MovieNameDashPosterJPG
        Me.rbDashTrailer.Checked = Master.eSettings.DashTrailer
        Me.chkSeasonXXDashFanartJPG.Checked = Master.eSettings.SeasonXXDashFanartJPG

        Me.chkMovieTBN.Checked = Master.eSettings.MovieTBN
        Me.chkMovieNameTBN.Checked = Master.eSettings.MovieNameTBN
        Me.chkMovieJPG.Checked = Master.eSettings.MovieJPG
        Me.chkMovieNameJPG.Checked = Master.eSettings.MovieNameJPG
        Me.chkPosterTBN.Checked = Master.eSettings.PosterTBN
        Me.chkPosterJPG.Checked = Master.eSettings.PosterJPG
        Me.chkFolderJPG.Checked = Master.eSettings.FolderJPG
        Me.chkFanartJPG.Checked = Master.eSettings.FanartJPG
        Me.chkMovieNameFanartJPG.Checked = Master.eSettings.MovieNameFanartJPG
        Me.chkMovieNameDotFanartJPG.Checked = Master.eSettings.MovieNameDotFanartJPG
        Me.chkMovieNFO.Checked = Master.eSettings.MovieNFO
        Me.chkMovieNameNFO.Checked = Master.eSettings.MovieNameNFO
        Me.chkMovieNameNFOStack.Checked = Master.eSettings.MovieNameNFOStack
        Me.chkMovieNameMultiOnly.Checked = Master.eSettings.MovieNameMultiOnly
        tLang = Master.eSettings.Language
        Me.cbIntLang.SelectedItem = Master.eSettings.Language
        Me.chkSeasonAllTBN.Checked = Master.eSettings.SeasonAllTBN
        Me.chkSeasonAllJPG.Checked = Master.eSettings.SeasonAllJPG
        Me.chkShowTBN.Checked = Master.eSettings.ShowTBN
        Me.chkShowJPG.Checked = Master.eSettings.ShowJPG
        Me.chkShowFolderJPG.Checked = Master.eSettings.ShowFolderJPG
        Me.chkShowPosterTBN.Checked = Master.eSettings.ShowPosterTBN
        Me.chkShowPosterJPG.Checked = Master.eSettings.ShowPosterJPG
        Me.chkShowFanartJPG.Checked = Master.eSettings.ShowFanartJPG
        Me.chkShowDashFanart.Checked = Master.eSettings.ShowDashFanart
        Me.chkShowDotFanart.Checked = Master.eSettings.ShowDotFanart
        Me.chkSeasonXXTBN.Checked = Master.eSettings.SeasonXX
        Me.chkSeasonXTBN.Checked = Master.eSettings.SeasonX
        Me.chkSeasonPosterTBN.Checked = Master.eSettings.SeasonPosterTBN
        Me.chkSeasonPosterJPG.Checked = Master.eSettings.SeasonPosterJPG
        Me.chkSeasonNameTBN.Checked = Master.eSettings.SeasonNameTBN
        Me.chkSeasonNameJPG.Checked = Master.eSettings.SeasonNameJPG
        Me.chkSeasonFolderJPG.Checked = Master.eSettings.SeasonFolderJPG
        Me.chkSeasonFanartJPG.Checked = Master.eSettings.SeasonFanartJPG
        Me.chkSeasonDashFanart.Checked = Master.eSettings.SeasonDashFanart
        Me.chkSeasonDotFanart.Checked = Master.eSettings.SeasonDotFanart
        Me.chkEpisodeTBN.Checked = Master.eSettings.EpisodeTBN
        Me.chkEpisodeJPG.Checked = Master.eSettings.EpisodeJPG
        Me.chkEpisodeDashThumbJPG.Checked = Master.eSettings.EpisodeDashThumbJPG
        Me.chkEpisodeDashFanart.Checked = Master.eSettings.EpisodeDashFanart
        Me.chkEpisodeDotFanart.Checked = Master.eSettings.EpisodeDotFanart
        'Me.tLangList.AddRange(Master.eSettings.TVDBLanguages)
        Me.cbTVLanguage.Items.AddRange((From lLang In Master.eSettings.Languages Select lLang.LongLang).ToArray)
        If Me.cbTVLanguage.Items.Count > 0 Then
            Me.cbTVLanguage.Text = Master.eSettings.Languages.FirstOrDefault(Function(l) l.ShortLang = AdvancedSettings.GetSetting("TVDBLanguage", "en")).LongLang
        End If
    End Sub

    Private Sub LoadIntLangs()
        If Directory.Exists(Path.Combine(Functions.AppPath, "Langs")) Then
            Dim alL As New List(Of String)
            Dim alLangs As New List(Of String)
            Try
                alL.AddRange(Directory.GetFiles(Path.Combine(Functions.AppPath, "Langs"), "*).xml"))
            Catch
            End Try
            alLangs.AddRange(alL.Cast(Of String)().Select(Function(AL) Path.GetFileNameWithoutExtension(AL)).ToArray)
            Me.cbIntLang.Items.AddRange(alLangs.ToArray)
        End If
    End Sub

    Private Sub lvMovies_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvMovies.DoubleClick
        If lvMovies.SelectedItems.Count > 0 Then
            Using dMovieSource As New dlgMovieSource
                If dMovieSource.ShowDialog(Convert.ToInt32(lvMovies.SelectedItems(0).Text)) = Windows.Forms.DialogResult.OK Then
                    Me.RefreshSources()
                End If
            End Using
        End If
    End Sub

    Private Sub lvMovies_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvMovies.KeyDown
        If e.KeyCode = Keys.Delete Then Me.RemoveSource()
    End Sub

    Private Sub lvTVSources_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvTVSources.DoubleClick
        If lvTVSources.SelectedItems.Count > 0 Then
            Using dTVSource As New dlgTVSource
                If dTVSource.ShowDialog(Convert.ToInt32(lvTVSources.SelectedItems(0).Text)) = Windows.Forms.DialogResult.OK Then
                    Me.RefreshTVSources()
                End If
            End Using
        End If
    End Sub

    Private Sub lvTVSources_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTVSources.KeyDown
        If e.KeyCode = Keys.Delete Then Me.RemoveTVSource()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.SaveSettings()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub RefreshSources()
        Dim lvItem As ListViewItem

        lvMovies.Items.Clear()
        Master.DB.LoadMovieSourcesFromDB()
        For Each s As Structures.MovieSource In Master.MovieSources
            lvItem = New ListViewItem(s.id)
            lvItem.SubItems.Add(s.Name)
            lvItem.SubItems.Add(s.Path)
            tmppath = s.Path
            lvItem.SubItems.Add(If(s.Recursive, "Yes", "No"))
            lvItem.SubItems.Add(If(s.UseFolderName, "Yes", "No"))
            lvItem.SubItems.Add(If(s.IsSingle, "Yes", "No"))
            lvMovies.Items.Add(lvItem)
        Next
    End Sub

    Private Sub RefreshTVSources()
        Dim lvItem As ListViewItem
        Master.DB.LoadTVSourcesFromDB()
        lvTVSources.Items.Clear()
        Using SQLcommand As SQLite.SQLiteCommand = Master.DB.MediaDBConn.CreateCommand()
            SQLcommand.CommandText = "SELECT * FROM TVSources;"
            Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                While SQLreader.Read
                    lvItem = New ListViewItem(SQLreader("ID").ToString)
                    lvItem.SubItems.Add(SQLreader("Name").ToString)
                    lvItem.SubItems.Add(SQLreader("Path").ToString)
                    tmppath = SQLreader("Path").ToString
                    lvTVSources.Items.Add(lvItem)
                End While
            End Using
        End Using
    End Sub

    Private Sub RemoveSource()
        Try
            If Me.lvMovies.SelectedItems.Count > 0 Then
                If MsgBox(Master.eLang.GetString(418, "Are you sure you want to remove the selected sources? This will remove the movies from these sources from the Ember database."), MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Master.eLang.GetString(104, "Are You Sure?")) = MsgBoxResult.Yes Then
                    Me.lvMovies.BeginUpdate()

                    Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.MediaDBConn.BeginTransaction()
                        Using SQLcommand As SQLite.SQLiteCommand = Master.DB.MediaDBConn.CreateCommand()
                            Dim parSource As SQLite.SQLiteParameter = SQLcommand.Parameters.Add("parSource", DbType.String, 0, "source")
                            While Me.lvMovies.SelectedItems.Count > 0
                                parSource.Value = lvMovies.SelectedItems(0).SubItems(1).Text
                                SQLcommand.CommandText = String.Concat("DELETE FROM movies WHERE source = (?);")
                                SQLcommand.ExecuteNonQuery()
                                SQLcommand.CommandText = String.Concat("DELETE FROM sources WHERE name = (?);")
                                SQLcommand.ExecuteNonQuery()
                                lvMovies.Items.Remove(Me.lvMovies.SelectedItems(0))
                            End While
                        End Using
                        SQLtransaction.Commit()
                    End Using

                    Me.lvMovies.Sort()
                    Me.lvMovies.EndUpdate()
                    Me.lvMovies.Refresh()
                End If
            End If
        Catch ex As Exception
            Master.eLog.Error(Me.GetType(), ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub RemoveTVSource()
        Try
            If Me.lvTVSources.SelectedItems.Count > 0 Then
                If MsgBox(Master.eLang.GetString(418, "Are you sure you want to remove the selected sources? This will remove the TV Shows from these sources from the Ember database."), MsgBoxStyle.Question Or MsgBoxStyle.YesNo, Master.eLang.GetString(104, "Are You Sure?")) = MsgBoxResult.Yes Then
                    Me.lvTVSources.BeginUpdate()

                    Using SQLtransaction As SQLite.SQLiteTransaction = Master.DB.MediaDBConn.BeginTransaction()
                        Using SQLcommand As SQLite.SQLiteCommand = Master.DB.MediaDBConn.CreateCommand()
                            Dim parSource As SQLite.SQLiteParameter = SQLcommand.Parameters.Add("parSource", DbType.String, 0, "source")
                            While Me.lvTVSources.SelectedItems.Count > 0
                                parSource.Value = lvTVSources.SelectedItems(0).SubItems(1).Text
                                SQLcommand.CommandText = "SELECT Id FROM TVShows WHERE Source = (?);"
                                Using SQLReader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                                    While SQLReader.Read
                                        Master.DB.DeleteTVShowFromDB(Convert.ToInt64(SQLReader("ID")), True)
                                    End While
                                End Using
                                SQLcommand.CommandText = String.Concat("DELETE FROM TVSources WHERE name = (?);")
                                SQLcommand.ExecuteNonQuery()
                                lvTVSources.Items.Remove(lvTVSources.SelectedItems(0))
                            End While
                        End Using
                        SQLtransaction.Commit()
                    End Using

                    Me.lvTVSources.Sort()
                    Me.lvTVSources.EndUpdate()
                    Me.lvTVSources.Refresh()
                End If
            End If
        Catch ex As Exception
            Master.eLog.Error(Me.GetType(), ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub SaveSettings()

        Master.eSettings.UseFrodo = Me.chkUseFrodo.Checked
        Master.eSettings.ActorThumbsFrodo = Me.chkActorThumbsFrodo.Checked
        Master.eSettings.BannerFrodo = Me.chkBannerFrodo.Checked
        Master.eSettings.ClearArtFrodo = Me.chkClearArtFrodo.Checked
        Master.eSettings.ClearLogoFrodo = Me.chkClearLogoFrodo.Checked
        Master.eSettings.DiscArtFrodo = Me.chkDiscArtFrodo.Checked
        Master.eSettings.ExtrafanartsFrodo = Me.chkExtrafanartsFrodo.Checked
        Master.eSettings.ExtrathumbsFrodo = Me.chkExtrathumbsFrodo.Checked
        Master.eSettings.FanartFrodo = Me.chkFanartFrodo.Checked
        Master.eSettings.LandscapeFrodo = Me.chkLandscapeFrodo.Checked
        Master.eSettings.NFOFrodo = Me.chkNFOFrodo.Checked
        Master.eSettings.PosterFrodo = Me.chkPosterFrodo.Checked
        Master.eSettings.TrailerFrodo = Me.chkTrailerFrodo.Checked

        Master.eSettings.UseEden = Me.chkUseEden.Checked
        Master.eSettings.ActorThumbsEden = Me.chkActorThumbsEden.Checked
        Master.eSettings.ExtrafanartsEden = Me.chkExtrafanartsEden.Checked
        Master.eSettings.ExtrathumbsEden = Me.chkExtrathumbsEden.Checked
        Master.eSettings.FanartEden = Me.chkFanartEden.Checked
        Master.eSettings.NFOEden = Me.chkNFOEden.Checked
        Master.eSettings.PosterEden = Me.chkPosterEden.Checked
        Master.eSettings.TrailerEden = Me.chkTrailerEden.Checked

        Master.eSettings.XBMCTrailerFormat = Me.chkXBMCTrailerFormat.Checked

        Master.eSettings.UseYAMJ = Me.chkUseYAMJ.Checked
        Master.eSettings.BannerYAMJ = Me.chkBannerYAMJ.Checked
        Master.eSettings.FanartYAMJ = Me.chkFanartYAMJ.Checked
        Master.eSettings.NFOYAMJ = Me.chkNFONMJ.Checked
        Master.eSettings.PosterYAMJ = Me.chkPosterYAMJ.Checked
        Master.eSettings.TrailerYAMJ = Me.chkTrailerYAMJ.Checked

        Master.eSettings.UseNMJ = Me.chkUseNMJ.Checked
        Master.eSettings.BannerNMJ = Me.chkBannerNMJ.Checked
        Master.eSettings.FanartNMJ = Me.chkFanartNMJ.Checked
        Master.eSettings.NFONMJ = Me.chkNFONMJ.Checked
        Master.eSettings.PosterNMJ = Me.chkPosterNMJ.Checked
        Master.eSettings.TrailerNMJ = Me.chkTrailerNMJ.Checked

        Master.eSettings.SeasonAllPosterJPG = Me.chkSeasonAllPosterJPG.Checked
        Master.eSettings.SeasonXXDashPosterJPG = Me.chkSeasonXXDashPosterJPG.Checked
        Master.eSettings.MovieNameDashPosterJPG = Me.chkMovieNameDashPosterJPG.Checked
        Master.eSettings.DashTrailer = Me.rbDashTrailer.Checked
        Master.eSettings.SeasonXXDashFanartJPG = Me.chkSeasonXXDashFanartJPG.Checked
        Master.eSettings.MovieTBN = Me.chkMovieTBN.Checked
        Master.eSettings.MovieNameTBN = Me.chkMovieNameTBN.Checked
        Master.eSettings.MovieJPG = Me.chkMovieJPG.Checked
        Master.eSettings.MovieNameJPG = Me.chkMovieNameJPG.Checked
        Master.eSettings.PosterTBN = Me.chkPosterTBN.Checked
        Master.eSettings.PosterJPG = Me.chkPosterJPG.Checked
        Master.eSettings.FolderJPG = Me.chkFolderJPG.Checked
        Master.eSettings.FanartJPG = Me.chkFanartJPG.Checked
        Master.eSettings.MovieNameFanartJPG = Me.chkMovieNameFanartJPG.Checked
        Master.eSettings.MovieNameDotFanartJPG = Me.chkMovieNameDotFanartJPG.Checked
        Master.eSettings.MovieNFO = Me.chkMovieNFO.Checked
        Master.eSettings.MovieNameNFO = Me.chkMovieNameNFO.Checked
        Master.eSettings.MovieNameNFOStack = Me.chkMovieNameNFOStack.Checked
        Master.eSettings.MovieNameMultiOnly = Me.chkMovieNameMultiOnly.Checked
        Master.eSettings.Language = Me.cbIntLang.Text
        Master.eSettings.SeasonAllTBN = Me.chkSeasonAllTBN.Checked
        Master.eSettings.SeasonAllJPG = Me.chkSeasonAllJPG.Checked
        Master.eSettings.ShowTBN = Me.chkShowTBN.Checked
        Master.eSettings.ShowJPG = Me.chkShowJPG.Checked
        Master.eSettings.ShowFolderJPG = Me.chkShowFolderJPG.Checked
        Master.eSettings.ShowPosterTBN = Me.chkShowPosterTBN.Checked
        Master.eSettings.ShowPosterJPG = Me.chkShowPosterJPG.Checked
        Master.eSettings.ShowFanartJPG = Me.chkShowFanartJPG.Checked
        Master.eSettings.ShowDashFanart = Me.chkShowDashFanart.Checked
        Master.eSettings.ShowDotFanart = Me.chkShowDotFanart.Checked
        Master.eSettings.SeasonXX = Me.chkSeasonXXTBN.Checked
        Master.eSettings.SeasonX = Me.chkSeasonXTBN.Checked
        Master.eSettings.SeasonPosterTBN = Me.chkSeasonPosterTBN.Checked
        Master.eSettings.SeasonPosterJPG = Me.chkSeasonPosterJPG.Checked
        Master.eSettings.SeasonNameTBN = Me.chkSeasonNameTBN.Checked
        Master.eSettings.SeasonNameJPG = Me.chkSeasonNameJPG.Checked
        Master.eSettings.SeasonFolderJPG = Me.chkSeasonFolderJPG.Checked
        Master.eSettings.SeasonFanartJPG = Me.chkSeasonFanartJPG.Checked
        Master.eSettings.SeasonDashFanart = Me.chkSeasonDashFanart.Checked
        Master.eSettings.SeasonDotFanart = Me.chkSeasonDotFanart.Checked
        Master.eSettings.EpisodeTBN = Me.chkEpisodeTBN.Checked
        Master.eSettings.EpisodeJPG = Me.chkEpisodeJPG.Checked
        Master.eSettings.EpisodeDashThumbJPG = Me.chkEpisodeDashThumbJPG.Checked
        Master.eSettings.EpisodeDashFanart = Me.chkEpisodeDashFanart.Checked
        Master.eSettings.EpisodeDotFanart = Me.chkEpisodeDotFanart.Checked

        Using settings = New AdvancedSettings()
            If Master.eSettings.Languages.Count > 0 Then
                Dim tLang As String = Master.eSettings.Languages.FirstOrDefault(Function(l) l.LongLang = Me.cbTVLanguage.Text).ShortLang
                If Not String.IsNullOrEmpty(tLang) Then
                    settings.SetSetting("TVDBLanguage", tLang)
                Else
                    settings.SetSetting("TVDBLanguage", "en")
                End If
            Else
                settings.SetSetting("TVDBLanguage", "en")
            End If
            'Master.eSettings.TVDBLanguages = Me.tLangList
        End Using
    End Sub

    Private Sub SetUp()
        Me.btnTVShowFrodo.Text = Master.eLang.GetString(867, "XBMC Frodo")
        Me.Text = Master.eLang.GetString(402, "Ember Startup Wizard")
        Me.OK_Button.Text = Master.eLang.GetString(179, "OK")
        Me.Cancel_Button.Text = Master.eLang.GetString(167, "Cancel")
        Me.btnBack.Text = Master.eLang.GetString(403, "< Back")
        Me.btnNext.Text = Master.eLang.GetString(404, "Next >")
        Me.Label1.Text = Master.eLang.GetString(405, "Welcome to Ember Media Manager")
        Me.GroupBox6.Text = Master.eLang.GetString(149, "Fanart")
        Me.GroupBox5.Text = Master.eLang.GetString(148, "Poster")
        Me.Label5.Text = Master.eLang.GetString(406, "TIP: Selections containing the text <movie> means that Ember Media Manager will use the filename of the movie.")
        Me.btnMovieRem.Text = Master.eLang.GetString(30, "Remove")
        Me.btnTVRemoveSource.Text = Me.btnMovieRem.Text
        Me.btnMovieAddFolder.Text = Master.eLang.GetString(407, "Add Source")
        Me.btnTVAddSource.Text = Me.btnMovieAddFolder.Text
        Me.Label6.Text = Master.eLang.GetString(408, "That wasn't so hard was it?  As mentioned earlier, you can change these or any other options in the Settings dialog.")
        Me.Label7.Text = String.Format(Master.eLang.GetString(409, "That's it!{0}Ember Media Manager is Ready!"), vbNewLine)
        Me.colName.Text = Master.eLang.GetString(232, "Name")
        Me.colPath.Text = Master.eLang.GetString(410, "Path")
        Me.colRecur.Text = Master.eLang.GetString(411, "Recursive")
        Me.colFolder.Text = Master.eLang.GetString(412, "Use Folder Name")
        Me.colSingle.Text = Master.eLang.GetString(413, "Single Video")
        Me.Label2.Text = String.Format(Master.eLang.GetString(415, "This is either your first time running Ember Media Manager or you have upgraded to a newer version.  There are a few things Ember Media Manager needs to know to work properly.  This wizard will walk you through configuring Ember Media Manager to work for your set up.{0}{0}Only a handful of settings will be covered in this wizard. You can change these or any other setting at any time by selecting ""Settings..."" from the ""Edit"" menu."), vbNewLine)
        Me.Label4.Text = Master.eLang.GetString(416, "Now that Ember Media Manager knows WHERE to look for the files, we need to tell it WHAT files to look for.  Simply select any combination of files type you wish Ember Media Manager to load from and save to.  You can select more than one from each section if you wish.")
        Me.Label3.Text = Master.eLang.GetString(414, "First, let's tell Ember Media Manager where to locate all your movies. You can add as many sources as you wish.")
        Me.Label8.Text = String.Format(Master.eLang.GetString(417, "Some options you may be interested in:{0}{0}Custom Filters - If your movie files have things like ""DVDRip"", ""BluRay"", ""x264"", etc in their folder or file name and you wish to filter the names when loading into the media list, you can utilize the Custom Filter option.  The custom filter is RegEx compatible for maximum usability.{0}{0}Images - This section allows you to select which websites to ""scrape"" images from as well as select a preferred size for the images Ember Media Manager selects.{0}{0}Locks - This section allows you to ""lock"" certain information so it does not get updated even if you re-scrape the movie. This is useful if you manually edit the title, outline, or plot of a movie and wish to keep your changes."), vbNewLine)
        Me.chkMovieNameMultiOnly.Text = Master.eLang.GetString(472, "Use <movie> Only for Folders with Multiple Movies")
        Me.Label32.Text = Master.eLang.GetString(430, "Interface Language")
        Me.Label9.Text = Master.eLang.GetString(803, "Next, let's tell Ember Media Manager where to locate all your TV Shows. You can add as many sources as you wish.")
        Me.Label11.Text = Master.eLang.GetString(804, "And finally, let's tell Ember Media Manager what TV Show files to look for.  Simply select any combination of files type you wish Ember Media Manager to load from and save to.  You can select more than one from each section if you wish.")
        Me.gbShowPosters.Text = Master.eLang.GetString(683, "Show Posters")
        Me.gbShowFanart.Text = Master.eLang.GetString(684, "Show Fanart")
        Me.gbSeasonPosters.Text = Master.eLang.GetString(685, "Season Posters")
        Me.gbSeasonFanart.Text = Master.eLang.GetString(686, "Season Fanart")
        Me.gbEpisodePosters.Text = Master.eLang.GetString(687, "Episode Posters")
        Me.gbEpisodeFanart.Text = Master.eLang.GetString(688, "Episode Fanart")
        Me.lblInsideSeason.Text = Master.eLang.GetString(834, "* Inside Season directory")
        Me.gbAllSeasonPoster.Text = Master.eLang.GetString(735, "All Season Posters")
        Me.Label10.Text = Master.eLang.GetString(113, "Now select the default language you would like Ember to look for when scraping TV Show items.")
        Me.pnlWelcome.Location = New Point(166, 7)
        Me.pnlWelcome.Visible = True
        Me.pnlMovieSource.Visible = False
        Me.pnlMovieSettings.Visible = False
        Me.pnlTVShowSource.Visible = False
        Me.pnlTVShowSettings.Visible = False
        Me.pnlDone.Visible = False
        Me.pnlMovieSource.Location = New Point(166, 7)
        Me.pnlMovieSettings.Location = New Point(166, 7)
        Me.pnlTVShowSource.Location = New Point(166, 7)
        Me.pnlTVShowSettings.Location = New Point(166, 7)
        Me.pnlDone.Location = New Point(166, 7)
	End Sub

	Private Sub btnTVShowFrodo_Click(sender As Object, e As EventArgs) Handles btnTVShowFrodo.Click
		Me.chkEpisodeDashFanart.Checked = False
		Me.chkEpisodeDashThumbJPG.Checked = True
		Me.chkEpisodeDotFanart.Checked = False
        Me.chkEpisodeJPG.Checked = False
		Me.chkEpisodeTBN.Checked = False
		Me.chkSeasonAllJPG.Checked = False
		Me.chkSeasonAllPosterJPG.Checked = True
		Me.chkSeasonAllTBN.Checked = False
		Me.chkSeasonDashFanart.Checked = False
		Me.chkSeasonDotFanart.Checked = False
		Me.chkSeasonFanartJPG.Checked = False
		Me.chkSeasonFolderJPG.Checked = False
		Me.chkSeasonNameJPG.Checked = False
		Me.chkSeasonNameTBN.Checked = False
		Me.chkSeasonPosterJPG.Checked = False
		Me.chkSeasonPosterTBN.Checked = False
		Me.chkSeasonXTBN.Checked = False
		Me.chkSeasonXXDashFanartJPG.Checked = True
		Me.chkSeasonXXDashPosterJPG.Checked = True
		Me.chkSeasonXXTBN.Checked = False
		'Me.chkShowBannerJPG.Checked = True (banners not implemented at time)
		Me.chkShowDashFanart.Checked = False
		Me.chkShowDotFanart.Checked = False
		Me.chkShowFanartJPG.Checked = True
		Me.chkShowFolderJPG.Checked = False
		Me.chkShowJPG.Checked = False
		Me.chkShowPosterJPG.Checked = True
		Me.chkShowPosterTBN.Checked = False
		Me.chkShowTBN.Checked = False
	End Sub

#End Region	'Methods

End Class